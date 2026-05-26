using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    
    protected float currentHealth;
    protected float moveSpeed;
    protected float damage;
    protected Transform target;
    protected MonsterDataSO monsterData;

    public virtual void Initialize(MonsterDataSO data, Transform targetTransform)
    {
        monsterData = data;

        target = targetTransform;

        currentHealth = data.MaxHealth;

        moveSpeed = data.MoveSpeed;

        damage = data.Damage;
        
        spriteRenderer.sprite = data.Icon;
    }

    protected virtual void Update()
    {
        MoveToTarget();
    }

    protected virtual void MoveToTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        PlayDeathSound();

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player == null)
        {
            return;
        }
        
        player.TakeDamage(damage);
    }
    
    private void PlayDeathSound()
    {
        if (monsterData.DeathSound == null)
        {
            return;
        }

        GameObject tempAudioObject = new GameObject("TempDeathAudio");

        tempAudioObject.transform.position = transform.position;

        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();

        audioSource.clip = monsterData.DeathSound;

        audioSource.spatialBlend = 0f;
        
        audioSource.volume = 0.5f;

        audioSource.pitch = Random.Range(0.8f, 1.2f);

        audioSource.Play();

        Destroy(
            tempAudioObject,
            monsterData.DeathSound.length
        );
    }
}