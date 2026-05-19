using UnityEngine;

public class CameraSystem : MonoBehaviour, IFearSystemObserver
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CameraConfigSO cameraConfig;
    [SerializeField] private float baseOrthographicSize = 5f;

    private Vector3 originalPosition;
    private float currentShakeIntensity;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition =
            originalPosition +
            (Vector3)Random.insideUnitCircle * currentShakeIntensity;
    }

    public void OnFearChanged(float fearLevel)
    {
        CameraFearData data = GetCameraData(fearLevel);

        if (data == null)
        {
            return;
        }

        currentShakeIntensity = data.ShakeIntensity;

        mainCamera.orthographicSize =
            baseOrthographicSize - data.Zoom;
    }

    private CameraFearData GetCameraData(float fearLevel)
    {
        foreach (CameraFearData data in cameraConfig.CameraSettings)
        {
            if (fearLevel >= data.MinFear && fearLevel <= data.MaxFear)
            {
                return data;
            }
        }

        return null;
    }
}