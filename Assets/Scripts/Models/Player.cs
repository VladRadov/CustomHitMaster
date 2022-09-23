using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BaseAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private BaseAnimator _baseAnimator;

    [SerializeField] private Weapon _weapon;

    private Camera _camera;

    public Vector3 CurrentPosition => new Vector3(transform.position.x, 0, transform.position.z);

    private void Start()
    {
        _baseAnimator.EntryAnimatorController("Player", gameObject);
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount != 0)
        {
            var target = Input.touchCount != 0 ? new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 1) : Input.mousePosition;
            Vector3 screenPoint = _camera.ScreenPointToRay(target).direction;
            _weapon.Shot(transform.position, new Vector3(screenPoint.x, screenPoint.y + 0.3f, screenPoint.z));
        }

    }

    public void Move(Vector3 direction)
    {
        _baseAnimator.SetBool("IsRun", true);
        _navMeshAgent.SetDestination(new Vector3(direction.x, transform.position.y, direction.z));
    }

    public void Stop()
    {
        _baseAnimator.SetBool("IsRun", false);
    }
}
