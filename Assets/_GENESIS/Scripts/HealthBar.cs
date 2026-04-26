using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Camera cameraRef;
    public Transform target;
    public Vector3 offset;

    void Awake()
    {
        slider = GetComponent<Slider>();
        cameraRef = Camera.FindFirstObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cameraRef.transform.rotation;
        transform.position = target.position + offset;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
