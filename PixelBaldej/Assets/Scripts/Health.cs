using UnityEngine;

public class Health : MonoBehaviour
{
    public Sprite zeroHealth;
    public Sprite oneHealth;

    public GameObject explosionPrefab;

    private SpriteRenderer spriteRenderer;

    public int amountOfHealth;

    private Collider2D heartCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        heartCollider = GetComponent<Collider2D>();
    }

    public void DecreaseHP(int damage)
    {
        amountOfHealth -= damage;
        AudioManager.instance.Play("Explosion");
        Explode();

        if (amountOfHealth == 0)
            AdjustCollider(false, zeroHealth);

        if (amountOfHealth < 0)
        {
            GameMaster.instance.Lose();
            return;
        }

        if (amountOfHealth >= 1)
        {
            amountOfHealth = 1;
            AdjustCollider(true, oneHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawningObject")
            DecreaseHP(1);
    }

    private void AdjustCollider(bool activeOrNot, Sprite sprite)
    {
        heartCollider.enabled = activeOrNot;
        spriteRenderer.sprite = sprite;
    }

    private void Explode()
    {
        GameObject explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
    }
}
