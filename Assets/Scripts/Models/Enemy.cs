using UnityEngine;

[RequireComponent(typeof(BaseAnimator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private bool _isDead;

    [SerializeField] private BaseAnimator _baseAnimator;

    [SerializeField] private Rigidbody[] _ragdolls;

    public bool IsDead => _isDead;

    private void Start()
    {
        _isDead = false;
        _baseAnimator.EntryAnimatorController("Enemy", gameObject);
        SetRagdolls(true);
        _health.DethEventHandler.AddListener(OnDeth);
    }

    private void OnDeth()
    {
        _baseAnimator.SetEnableAnimator(false);
        _isDead = true;
        SetRagdolls(false);
    }

    private void SetRagdolls(bool setValue)
    {
        for (int i = 0; i < _ragdolls.Length; i++)
            _ragdolls[i].isKinematic = setValue;
    }
}
