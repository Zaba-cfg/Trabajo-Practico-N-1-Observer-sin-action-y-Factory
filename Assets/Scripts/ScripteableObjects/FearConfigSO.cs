using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FearConfig", menuName = "Game/Fear Config" )]
public class FearConfigSO : ScriptableObject
{
    public List<FearVisualData> FearVisuals;
}