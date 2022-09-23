using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] float _damage;

    private bool _isEmpty;

    public Vector3 TargetPosition;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
            Move();
    }

    private void Move()
    {
        _isEmpty = false;
        _rigidbody.velocity = TargetPosition * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && _isEmpty == false)
        {
            var root = collision.transform.GetComponentInParent<Health>();
            root.HealthDecrease(_damage);
        }
        _isEmpty = true;
        gameObject.SetActive(false);
    }
}
