using UnityEngine;

[CreateAssetMenu(menuName = "FearGame/Monster Data")]
public class MonsterDataSO : ScriptableObject
{
    [field: SerializeField] public string MonsterName { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public AudioClip DeathSound { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}