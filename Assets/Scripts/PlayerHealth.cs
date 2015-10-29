using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameObject damageEffect;
    public int healthCount = 2;
    public float destroyEffectIn = 0.5f;

    private GameObject[]  heart;

	void Start () {

        heart = GameObject.FindGameObjectsWithTag("Heart");
	}

    void OnTriggerEnter2D(Collider2D collider2D)    
    {
        GameObject collisionObject;
        collisionObject = collider2D.gameObject;

        if (collisionObject.tag == "Enemy")
        {

            healthCount--;
            Object prefabObject = new Object();
            prefabObject = Instantiate(damageEffect, transform.position, transform.rotation);


            if (healthCount > 0)
            {
                Destroy(collisionObject);

            }
            else
            {
                Destroy(gameObject);

            }

            Destroy(heart[heart.Length - 1]);
            Destroy(prefabObject, destroyEffectIn);

            if (healthCount >= 0)
                Destroy(heart[healthCount]);
            Destroy(collisionObject);
        }
    }


    private void createPause() {
        GameObject go = GameObject.FindGameObjectWithTag("EventSystem");
        PauseController pause = (PauseController)go.GetComponent(typeof(PauseController));
        pause.GamePause();
    }
}
