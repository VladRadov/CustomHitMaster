using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Route : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _wayPoints;

    [SerializeField] private Player _player;

    [SerializeField] private BaseSceneManager _baseSceneManager;

    private WayPoint _nextWayPoint;

    private UnityEvent<Vector3> _movingPlayerEventHandler = new UnityEvent<Vector3>();

    private UnityEvent _finishWayPointEventHandler = new UnityEvent();

    private UnityEvent _finishRouteEventHandler = new UnityEvent();

    private void Start()
    {
        Distance—alculation();
        Subscribe();
        GetNextPoint();
    }

    private void Subscribe()
    {
        _movingPlayerEventHandler.AddListener(_player.Move);
        _finishWayPointEventHandler.AddListener(_player.Stop);
        _finishRouteEventHandler.AddListener(_baseSceneManager.ReloadScene);
    }

    private void FixedUpdate()
    {
        if(_nextWayPoint.IsEnemiesAlive() == false)
            _movingPlayerEventHandler.Invoke(_nextWayPoint.transform.position);

        ChekingFinishNextWayPoint();
    }

    private void ChekingFinishNextWayPoint()
    {
        if (_player.CurrentPosition == _nextWayPoint.Position)
        {
            _finishWayPointEventHandler.Invoke();
            _nextWayPoint.IsPassed = true;
            if (IsFinishRoute())
                _finishRouteEventHandler.Invoke();
            else
                GetNextPoint();
        }
    }

    private bool IsFinishRoute() => _wayPoints.Find(wayPoint => wayPoint.IsPassed == false) == null ? true : false;

    private void Distance—alculation()
    {
        foreach(var wayPoint in _wayPoints)
            wayPoint.DistanceToPlayer = Vector3.Distance(_player.transform.position, wayPoint.transform.position);

        SortWayPoints();
    }

    private void SortWayPoints()
    {
        _wayPoints.Sort(delegate(WayPoint first, WayPoint second) { return first.DistanceToPlayer.CompareTo(second.DistanceToPlayer); });
    }

    private void GetNextPoint()
    {
        foreach (var wayPoint in _wayPoints)
        {
            if (wayPoint.IsPassed == false)
            {
                _nextWayPoint = wayPoint;
                break;
            }
        }
    }
}
