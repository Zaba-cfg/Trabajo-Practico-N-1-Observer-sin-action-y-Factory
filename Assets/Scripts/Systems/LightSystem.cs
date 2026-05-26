using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSystem : MonoBehaviour, IFearSystemObserver
{
    [Header("References")]
    [SerializeField] private Light2D globalLight;

    [SerializeField] private FearConfigSO fearConfig;

    [Header("Transition")]
    [SerializeField] private float transitionSpeed = 5f;

    private Color targetColor;

    private float targetIntensity;

    private void Update()
    {
        SmoothTransition();
    }

    public void OnFearChanged(float fearLevel)
    {
        FearVisualData data =
            GetFearVisualData(fearLevel);

        if (data == null)
        {
            return;
        }

        targetColor = data.LightColor;

        targetIntensity = data.LightIntensity;
    }

    private void SmoothTransition()
    {
        globalLight.color = Color.Lerp(
            globalLight.color,
            targetColor,
            transitionSpeed * Time.deltaTime
        );

        globalLight.intensity = Mathf.Lerp(
            globalLight.intensity,
            targetIntensity,
            transitionSpeed * Time.deltaTime
        );
    }

    private FearVisualData GetFearVisualData(
        float fearLevel)
    {
        foreach (FearVisualData data
                 in fearConfig.FearVisuals)
        {
            if (
                fearLevel >= data.MinFear &&
                fearLevel <= data.MaxFear
            )
            {
                return data;
            }
        }

        return null;
    }
}