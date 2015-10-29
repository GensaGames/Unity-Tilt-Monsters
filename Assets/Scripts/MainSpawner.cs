using UnityEngine;
using System.Collections;

public class MainSpawner : MonoBehaviour {

    public float spawnStartRange = 0f;
    public float spawnEndRange = 2f;
    public float spawnStartDelay = 0f;
    public int objectToDestroy = 6; 
    public GameObject[] gameObjects;		

    void Start()
    {
        Invoke("Spawn", spawnStartDelay);
    }


    void Spawn()
    {
        float randomTime = Random.Range(spawnStartRange, spawnEndRange);
        int gameObjectIndex = Random.Range(0, gameObjects.Length);

        var collider2D = gameObject.GetComponent<Collider2D>();
        float widthMin = collider2D.bounds.min.x;
        float widthMax = collider2D.bounds.max.x;

        float heightMin = collider2D.bounds.min.y;
        float heightMax = collider2D.bounds.max.y;

        Vector2 vector = new Vector2(
            Random.Range(widthMin, widthMax),
            Random.Range(heightMin, heightMax));

        Object prefabObject = new Object();
        prefabObject = Instantiate(gameObjects[gameObjectIndex], vector, transform.rotation);

        Destroy(prefabObject, objectToDestroy);
        Invoke("Spawn", randomTime);
    }
}
