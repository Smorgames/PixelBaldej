using UnityEngine;

public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float timeVariable;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.3f);

        timeVariable = 0f;
    }

    private void Update()
    {
        timeVariable += Time.deltaTime;

        Blink();

        if (timeVariable >= Mathf.PI * 2)
            timeVariable = 0f;
    }

    private void Blink()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, (Mathf.Sin(timeVariable) + 1) / 10f + 0.3f);
    }
}
