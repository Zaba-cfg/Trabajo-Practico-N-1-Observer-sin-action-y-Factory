using UnityEngine;

public class AutomaticShooter : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private Transform shootPoint;

    [SerializeField] private TargetDetector targetDetector;

    [SerializeField] private float fireRate = 0.5f;

    [SerializeField] private float projectileDamage = 10f;

    [SerializeField] private float projectileSpeed = 10f;

    private float shootTimer;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= fireRate)
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        MonsterBase target =
            targetDetector.GetClosestTarget();

        if (target == null)
        {
            return;
        }

        Shoot(target);

        shootTimer = 0f;
    }

    private void Shoot(MonsterBase target)
    {
        Projectile projectile =
            Instantiate(
                projectilePrefab,
                shootPoint.position,
                Quaternion.identity
            );

        projectile.Initialize(
            target,
            projectileDamage,
            projectileSpeed
        );
    }
}