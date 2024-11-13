using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI nameText;
    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        nameText = GetComponentInChildren<TextMeshProUGUI>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
    }

    private void HandleHPPctChanged(float pct)
    {
        slider.value = pct;
    }

    void Update()
    {
        slider.transform.LookAt(Camera.main.transform);
        nameText.transform.LookAt(Camera.main.transform);
    }
}