using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerSystem : MonoBehaviour, IFearSystemObserver
{
    [SerializeField] private List<SpawnTableSO> spawnTables;
    [SerializeField] private MonsterFactory monsterFactory;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 15f;

    private SpawnTableSO currentSpawnTable;
    private Coroutine spawnRoutine;

    public void OnFearChanged(float fearLevel)
    {
        SpawnTableSO newTable =
            GetSpawnTable(fearLevel);

        if (newTable == currentSpawnTable)
        {
            return;
        }

        currentSpawnTable = newTable;

        RestartSpawnRoutine();
    }

    private void RestartSpawnRoutine()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }

        if (currentSpawnTable != null)
        {
            spawnRoutine = StartCoroutine(SpawnLoop());
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnWave();

            yield return new WaitForSeconds(
                currentSpawnTable.SpawnInterval
            );
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentSpawnTable.MonstersPerWave; i++)
        {
            MonsterDataSO monsterData =
                GetRandomMonster();

            Vector2 spawnPosition =
                GetSpawnPosition();

            monsterFactory.CreateMonster(
                monsterData,
                spawnPosition
            );
        }
    }

    private MonsterDataSO GetRandomMonster()
    {
        List<SpawnEntry> entries =
            currentSpawnTable.SpawnEntries;

        float totalWeight = 0f;

        foreach (SpawnEntry entry in entries)
        {
            totalWeight += entry.SpawnWeight;
        }

        float randomValue =
            Random.Range(0f, totalWeight);

        float currentWeight = 0f;

        foreach (SpawnEntry entry in entries)
        {
            currentWeight += entry.SpawnWeight;

            if (randomValue <= currentWeight)
            {
                return entry.MonsterData;
            }
        }

        return entries[0].MonsterData;
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 randomDirection =
            Random.insideUnitCircle.normalized;

        return (Vector2)player.position +
               randomDirection * spawnRadius;
    }

    private SpawnTableSO GetSpawnTable(float fearLevel)
    {
        foreach (SpawnTableSO table in spawnTables)
        {
            if (
                fearLevel >= table.MinFearLevel &&
                fearLevel <= table.MaxFearLevel
            )
            {
                return table;
            }
        }

        return null;
    }
}