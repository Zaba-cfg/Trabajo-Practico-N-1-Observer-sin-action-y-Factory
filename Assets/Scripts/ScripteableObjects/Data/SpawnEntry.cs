using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public MonsterDataSO MonsterData;
    [Range(1f, 100f)]
    public float SpawnWeight;
}