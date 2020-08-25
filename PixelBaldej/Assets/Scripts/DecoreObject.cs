using UnityEngine;
using TMPro;

public class DecoreObject : MonoBehaviour
{
    public Sprite[] sprites;

    public GameObject scoreUI;

    public GameObject clickEffect;

    [SerializeField] private TextMeshProUGUI scoreText;

    private float rotationSpeed;
    private bool rightRotationDirection;

    private float sizeVariable;

    private SpriteRenderer spriteRenderer;

    private Collider2D circleCollider;

    private Sprite sprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<Collider2D>();

        rotationSpeed = Random.Range(10f, 50f);

        int variable = Random.Range(0, 2);

        if (variable == 0)
            rightRotationDirection = true;
        else
            rightRotationDirection = false;

        if (!rightRotationDirection)
            rotationSpeed = -rotationSpeed;

        sizeVariable = Random.Range(0.6f, 1.1f);

        transform.localScale = new Vector3(sizeVariable, sizeVariable, sizeVariable);

        sprite = sprites[Random.Range(0, sprites.Length)];
        spriteRenderer.sprite = sprite;

        scoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * rotationSpeed * Time.deltaTime);
        scoreUI.transform.Rotate(new Vector3(0f, 0f, 1f) * -rotationSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                if (circleCollider == touchedCollider)
                {
                    AudioManager.instance.Play("Burst");
                    Burst();
                }
            }
        }
    }

    public void Burst()
    {
        GameObject effect = (GameObject)Instantiate(clickEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().textureSheetAnimation.SetSprite(0, sprite);
        Destroy(effect, 3f);
    }
}
