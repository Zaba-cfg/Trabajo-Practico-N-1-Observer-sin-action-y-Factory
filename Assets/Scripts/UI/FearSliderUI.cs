using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FearSliderUI : MonoBehaviour
{
    [SerializeField] private Slider fearSlider;

    [SerializeField] private TMP_Text fearValueText;

    [SerializeField] private FearManager fearManager;

    private void Start()
    {
        fearSlider.onValueChanged.AddListener(OnSliderValueChanged);

        OnSliderValueChanged(fearSlider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        fearManager.SetFearLevel(value);

        fearValueText.text = $"Fear: {value:0}";
    }
}