using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _quantityHealth;

    public float QuantityHealth => _quantityHealth;

    public UnityEvent HealthDecreaseEventHandler = new UnityEvent();

    public UnityEvent DethEventHandler = new UnityEvent();

    public void HealthDecrease(float damage)
    {
        _quantityHealth -= damage;
        HealthDecreaseEventHandler.Invoke();

        ChekingDeth();
    }

    private void ChekingDeth()
    {
        if (_quantityHealth <= 0)
            DethEventHandler.Invoke();
    }
}
