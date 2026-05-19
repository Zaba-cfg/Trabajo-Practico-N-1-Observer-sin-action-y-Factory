using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FearGame/Fear Config")]
public class FearConfigSO : ScriptableObject
{
    [field: SerializeField]
    public List<FearVisualData> VisualSettings { get; private set; }
}