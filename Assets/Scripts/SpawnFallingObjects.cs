using UnityEngine;

public class SpawnFallingObjects : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefabs;
    [SerializeField] Transform startPositon;
    [SerializeField] Transform endPositon;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float minFallSpeed = 1f;
    [SerializeField] float maxFallSpeed = 3f;

    private float spawnTimer = 0f;

    private void Start() 
    {
        // BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        // float width = boxCollider.bounds.size.x;
        // Debug.Log("Width: " + width);

        //Debug.Log("Width: " + startPositon.transform.position);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomObject();
            spawnTimer = 0f;
        }
    }

    private void SpawnRandomObject()
    {
        Vector3 spawnPosition = transform.position;
        // spawnPosition.x = Random.Range(-spawnRadius, spawnRadius);
        spawnPosition.x = Random.Range(startPositon.position.x, endPositon.position.x);

        
        //spawnPosition.y += spawnRadius;
        Debug.Log(spawnPosition);

        Quaternion spawnRotation = Quaternion.identity;

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectPrefab = objectPrefabs[randomIndex];

        // Change the color to black if in dark mode

        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

        float fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * fallSpeed;
        }
    }

}
