using UnityEngine;

public class MonsterFactory : MonoBehaviour, IMonsterFactory
{
    [SerializeField] private Transform monstersContainer;

    [SerializeField] private Transform player;

    public MonsterBase CreateMonster(
        MonsterDataSO monsterData,
        Vector2 spawnPosition)
    {
        GameObject instance =
            Instantiate(
                monsterData.Prefab,
                spawnPosition,
                Quaternion.identity,
                monstersContainer
            );

        MonsterBase monster =
            instance.GetComponent<MonsterBase>();

        monster.Initialize(monsterData, player);

        return monster;
    }
}