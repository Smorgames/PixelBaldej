using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed;

    public Vector3 moveDirection;

    public float coordinateToRespawn;
    public float coordinateToSpawn;

    public bool leftDirection;

    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (transform.position.x <= coordinateToRespawn && leftDirection)
            transform.position = new Vector3(coordinateToSpawn, transform.position.y, transform.position.z);

        if (transform.position.x >= coordinateToRespawn && !leftDirection)
            transform.position = new Vector3(coordinateToSpawn, transform.position.y, transform.position.z);
    }
}
