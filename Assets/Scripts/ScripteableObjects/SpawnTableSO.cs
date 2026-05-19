using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FearGame/Spawn Table")]
public class SpawnTableSO : ScriptableObject
{
    [field: SerializeField] public float MinFearLevel { get; private set; }
    [field: SerializeField] public float MaxFearLevel { get; private set; }
    [field: SerializeField] public float SpawnInterval { get; private set; }
    [field: SerializeField] public int MonstersPerWave { get; private set; }
    [field: SerializeField] public List<SpawnEntry> SpawnEntries { get; private set; }
}