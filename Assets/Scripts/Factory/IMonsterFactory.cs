using UnityEngine;

public interface IMonsterFactory
{
    MonsterBase CreateMonster(
        MonsterDataSO monsterData,
        Vector2 spawnPosition
    );
}