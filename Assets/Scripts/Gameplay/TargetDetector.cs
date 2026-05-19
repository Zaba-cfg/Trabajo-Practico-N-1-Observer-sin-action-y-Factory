using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask monsterLayer;

    public MonsterBase GetClosestTarget()
    {
        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                transform.position,
                detectionRadius,
                monsterLayer
            );

        MonsterBase closestMonster = null;

        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hit in hits)
        {
            MonsterBase monster =
                hit.GetComponent<MonsterBase>();

            if (monster == null)
            {
                continue;
            }

            float distance = Vector2.Distance(
                transform.position,
                monster.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;

                closestMonster = monster;
            }
        }

        return closestMonster;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            detectionRadius
        );
    }
}