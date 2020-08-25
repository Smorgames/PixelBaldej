using UnityEngine;
using System.Collections;

public class SpawningObject : MonoBehaviour
{
    public GameObject number;

    public Sprite[] objectsColorAndShape;
    public Sprite[] numberSprite;

    [HideInInspector]
    public int colorAndShapeIndex;
    [HideInInspector]
    public int numberIndex;

    public float speed;

    public GameObject coolEffectPS;

    private Animator animator;

    private SpriteRenderer objectRenderer;
    private SpriteRenderer numberRenderer;

    private ObjectData objectData;

    private Collider2D objectCollider;

    private void Start()
    {
        Destroy(gameObject, 20f);

        objectData = new ObjectData();

        objectRenderer = GetComponent<SpriteRenderer>();
        numberRenderer = number.GetComponent<SpriteRenderer>();

        colorAndShapeIndex = Random.Range(0, objectsColorAndShape.Length);
        numberIndex = Random.Range(0, numberSprite.Length);

        for (int i = 0; i < objectsColorAndShape.Length; i++)
            if (i == colorAndShapeIndex)
                objectRenderer.sprite = objectsColorAndShape[colorAndShapeIndex];

        for (int i = 0; i < numberSprite.Length; i++)
            if (i == numberIndex)
                numberRenderer.sprite = numberSprite[numberIndex];

        SetObjectIndexes();

        animator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void SetObjectIndexes()
    {
        objectData.numberIndex = ++numberIndex;

        for (int i = 0; i <= 8; i++)
        {
            if (colorAndShapeIndex == i)
            {
                objectData.colorIndex = i / 3 + 1;
                objectData.shapeIndex = i % 3 + 1;
            }
        }
    }

    public ObjectData GetObjectData()
    {
        return objectData;
    }

    public void StartFallInHole(bool needCoolEffect)
    {
        objectCollider.enabled = false;
        speed = 2f;
        animator.SetTrigger("Fall");

        if (needCoolEffect)
            StartCoroutine(CoolEffect());
    }

    private IEnumerator CoolEffect()
    {
        yield return new WaitForSeconds(0.9f);
        GameObject effect = (GameObject)Instantiate(coolEffectPS, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().textureSheetAnimation.SetSprite(0, objectsColorAndShape[colorAndShapeIndex]);
        Destroy(effect, 3f);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
