using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FearGame/Camera Config")]
public class CameraConfigSO : ScriptableObject
{
    [field: SerializeField]
    public List<CameraFearData> CameraSettings { get; private set; }
}