using UnityEngine;
using System.Collections;

public class TreesSpawn : MonoBehaviour {

    public float spawnStartRange = 3f;
    public float spawnEndRange = 5f;
    public float spawnDelay = 0f;
    public float timeToDestroy = 7;

    public Vector2 spawnPlaceSimpleTree = new Vector2(0, 0);
    public Vector2 spawnPlaceDakrTree = new Vector2(0, 0);

    public GameObject[] trees;		



    void Start()
    {
        Spawn();
    }


    void Spawn()
    {
        float randomTime = Random.Range(spawnStartRange, spawnEndRange);
        int treesIndex = (Random.Range(0, trees.Length));
        Vector2 spawnPlace;

        if (trees [treesIndex] == GameObject.FindGameObjectWithTag("SimpleTree"))
            spawnPlace = spawnPlaceSimpleTree;
        
        else if ((trees [treesIndex] == GameObject.FindGameObjectWithTag("DarkTree")))
            spawnPlace = spawnPlaceDakrTree;
        
        
        else
            spawnPlace = spawnPlaceDakrTree;
        
        Object prefabObject = new Object();
        prefabObject = Instantiate(trees[treesIndex], spawnPlace, transform.rotation);

        Destroy(prefabObject, timeToDestroy);
        Invoke("Spawn", randomTime);
    }


}