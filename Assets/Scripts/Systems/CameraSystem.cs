using UnityEngine;

public class CameraSystem : MonoBehaviour, IFearSystemObserver
{
    [Header("References")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private CameraConfigSO cameraConfig;

    [Header("Transition")]
    [SerializeField] private float zoomTransitionSpeed = 5f;
    [SerializeField] private float shakeTransitionSpeed = 5f;

    [Header("Base Values")]
    [SerializeField] private float baseOrthographicSize = 5f;

    private float targetZoomOffset;
    private float currentShakeIntensity;
    private float targetShakeIntensity;
    private Vector3 basePosition;

    private void Start()
    {
        basePosition = new Vector3(0f, 0f, -10f);
    }

    private void LateUpdate()
    {
        SmoothZoom();
        SmoothShake();
    }

    public void OnFearChanged(float fearLevel)
    {
        CameraFearData data = GetCameraFearData(fearLevel);

        if (data == null)
        {
            return;
        }

        targetZoomOffset = data.ZoomOffset;

        targetShakeIntensity = data.ShakeIntensity;
    }

    private void SmoothZoom()
    {
        float targetSize = baseOrthographicSize + targetZoomOffset;

        targetCamera.orthographicSize =
            Mathf.Lerp(
                targetCamera.orthographicSize,
                targetSize,
                zoomTransitionSpeed * Time.deltaTime
            );
    }

    private void SmoothShake()
    {
        currentShakeIntensity =
            Mathf.Lerp(
                currentShakeIntensity,
                targetShakeIntensity,
                shakeTransitionSpeed * Time.deltaTime
            );

        Vector2 randomOffset = Random.insideUnitCircle * currentShakeIntensity;

        targetCamera.transform.position = basePosition + (Vector3)randomOffset;
    }

    private CameraFearData GetCameraFearData(float fearLevel)
    {
        foreach (CameraFearData data in cameraConfig.CameraFearData)
        {
            if (fearLevel >= data.MinFear && fearLevel <= data.MaxFear)
            {
                return data;
            }
        }

        return null;
    }
}