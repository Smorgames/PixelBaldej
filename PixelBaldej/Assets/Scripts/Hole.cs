using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool isHoleActive;

    public Vector3 positionForChosenHole;

    public GameObject projection;
    public GameObject projectionNumber;
    public Sprite[] projectionSprites;
    public Sprite[] projectionNumberSprites;
    private SpriteRenderer projectionSpriteRend;
    private SpriteRenderer projectionNumberSpriteRend;

    private Collider2D holeCollider;

    private ObjectData predictableObjectData;

    private GameObject chosenHole;

    public GameObject[] otherHoles;

    public GameObject buttonSet;

    public GameObject heart;
    private Health healthComponent;

    private void Start()
    {
        predictableObjectData = new ObjectData();

        predictableObjectData.colorIndex = 1;
        predictableObjectData.shapeIndex = 1;
        predictableObjectData.numberIndex = 1;

        holeCollider = GetComponent<Collider2D>();

        chosenHole = GameObject.FindWithTag("ChosenHole");

        projectionSpriteRend = projection.GetComponent<SpriteRenderer>();
        projectionNumberSpriteRend = projectionNumber.GetComponent<SpriteRenderer>();
        healthComponent = heart.GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                if (holeCollider == touchedCollider)
                {
                    chosenHole.SetActive(true);
                    chosenHole.transform.position = positionForChosenHole;

                    DisableOtherHolesAndEnableThis();
                }
            }
        }
    }

    public void SetObjectDataIndex(string indexName)
    {
        if (isHoleActive)
        {
            if (indexName == "Color")
            {
                predictableObjectData.colorIndex++;

                if (predictableObjectData.colorIndex == 4)
                    predictableObjectData.colorIndex = 1;
            }

            if (indexName == "Shape")
            {
                predictableObjectData.shapeIndex++;

                if (predictableObjectData.shapeIndex == 4)
                    predictableObjectData.shapeIndex = 1;
            }

            if (indexName == "Number")
            {
                predictableObjectData.numberIndex++;

                if (predictableObjectData.numberIndex == 4)
                    predictableObjectData.numberIndex = 1;
            }

            for (int i = 1; i < projectionNumberSprites.Length + 1; i++)
                if (predictableObjectData.numberIndex == i)
                    projectionNumberSpriteRend.sprite = projectionNumberSprites[(i - 1) % 3];

            for (int i = 0; i < projectionSprites.Length; i++)
                if (i % 3 + 1 == predictableObjectData.shapeIndex && i / 3 + 1 == predictableObjectData.colorIndex)
                    projectionSpriteRend.sprite = projectionSprites[i];
        }
    }

    private void DisableOtherHolesAndEnableThis()
    {
        for (int i = 0; i < otherHoles.Length; i++)
            otherHoles[i].GetComponent<Hole>().ActivateButtonSet(false);

        ActivateButtonSet(true);
    }

    public void ActivateButtonSet(bool isButtonSetActive)
    {
        buttonSet.SetActive(isButtonSetActive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawningObject" && isHoleActive && collision.GetComponent<SpawningObject>().GetObjectData().
            IsDataInformationSimilar(predictableObjectData.colorIndex, predictableObjectData.shapeIndex, predictableObjectData.numberIndex)) // and if object's data equals to predictable data in hole
        {
            collision.GetComponent<SpawningObject>().StartFallInHole(true);
            AudioManager.instance.Play("FallInHole");
            GameMaster.instance.ChangeScore(1);
        }

        else
        {
            AudioManager.instance.Play("FallInHole");
            collision.GetComponent<SpawningObject>().StartFallInHole(false);
            healthComponent.DecreaseHP(1);
        }
    }
}
