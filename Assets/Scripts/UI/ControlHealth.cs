using UnityEngine;
using UnityEngine.UI;

public class ControlHealth : MonoBehaviour
{
    [SerializeField] private Canvas _viewHealth;

    [SerializeField] private Slider _lineHealth;

    [SerializeField] Health _health;

    private void Start()
    {
        _lineHealth.minValue = 0;
        _lineHealth.maxValue = _health.QuantityHealth;
        _lineHealth.value = _health.QuantityHealth;
        _health.HealthDecreaseEventHandler.AddListener(SetValueSlider);
        _health.DethEventHandler.AddListener(OnDeth);
    }

    private void SetValueSlider()
    {
        _lineHealth.value = _health.QuantityHealth;
    }

    private void OnDeth()
    {
        _viewHealth.gameObject.SetActive(false);
    }
}
