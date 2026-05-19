using UnityEngine;

public class Projectile : MonoBehaviour
{
    private MonsterBase target;

    private float damage;

    private float speed;

    public void Initialize(
        MonsterBase targetMonster,
        float projectileDamage,
        float projectileSpeed)
    {
        target = targetMonster;

        damage = projectileDamage;

        speed = projectileSpeed;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);

            return;
        }

        Move();
    }

    private void Move()
    {
        Vector2 direction =
        (
            target.transform.position -
            transform.position
        ).normalized;

        transform.position +=
            (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MonsterBase monster =
            other.GetComponent<MonsterBase>();

        if (monster == null)
        {
            return;
        }

        monster.TakeDamage(damage);

        Destroy(gameObject);
    }
}