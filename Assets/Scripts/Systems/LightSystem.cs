using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSystem : MonoBehaviour, IFearSystemObserver
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private FearConfigSO fearConfig;

    public void OnFearChanged(float fearLevel)
    {
        FearVisualData data = GetVisualData(fearLevel);

        if (data == null)
        {
            return;
        }

        globalLight.color = data.LightColor;
        globalLight.intensity = data.LightIntensity;
    }

    private FearVisualData GetVisualData(float fearLevel)
    {
        foreach (FearVisualData data in fearConfig.VisualSettings)
        {
            if (fearLevel >= data.MinFear && fearLevel <= data.MaxFear)
            {
                return data;
            }
        }

        return null;
    }
}