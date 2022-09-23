using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public List<Enemy> Enemies => _enemies;

    public bool IsPassed { get; set; }

    public float DistanceToPlayer { get; set; }

    public Vector3 Position => new Vector3(transform.position.x, 0, transform.position.z);

    public bool IsEnemiesAlive() => FindAliveEnemy() == null ? false : true;

    private Enemy FindAliveEnemy() => _enemies.Find(enemy => enemy.IsDead == false);
}
