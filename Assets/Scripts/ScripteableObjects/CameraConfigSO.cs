using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName = "Game/Camera Config" )]
public class CameraConfigSO : ScriptableObject
{
    public List<CameraFearData> CameraFearData;
}