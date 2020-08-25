using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwaper : MonoBehaviour
{
    public Sprite[] images;

    private int imageIndex;
    private Image imageComponent;

    private void Start()
    {
        imageIndex = 1;
        imageComponent = GetComponent<Image>();
        imageComponent.sprite = images[0];
    }

    public void ChangeImage()
    {
        imageIndex++;

        if (imageIndex == 4)
            imageIndex = 1;

        for (int i = 1; i <= 3; i++)
            if (imageIndex == i)
                imageComponent.sprite = images[i - 1];
    }
}
