using UnityEngine;
using System.Collections;

public class EnemyMotion : MonoBehaviour {

    public Vector2 enemyMotion = new Vector2(1, 2);
    public float changeMotionInRange = 2f;
    public float changeMotionOnRange = 6f;
    public float endOfLeft = -3.75f;
    public float endOfRight = 3.75f;

    private Vector2 movement;
    private bool flip = false;

	void Start () {
        generateFlip();
        ChangeMotion();
	}

    
    void FixedUpdate()
    {
        if (gameObject.transform.position.x < endOfLeft ||
              gameObject.transform.position.x > endOfRight)
            ChangeMotion();
      
    }


    void generateFlip()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5)
            flip = false;
        else
            flip = true;    
    }

    void ChangeMotion()
    {
        float randomTime = Random.Range(changeMotionInRange, changeMotionOnRange);

        if (flip)
        {
            movement = new Vector2(
            enemyMotion.x ,
            enemyMotion.y );            
        }
        else 
        {
            movement = new Vector2(
             - enemyMotion.x ,
               enemyMotion.y );            
        }
        flip = !flip;
        GetComponent<Rigidbody2D>().velocity = movement;
        Invoke("ChangeMotion", randomTime);
    }

}
