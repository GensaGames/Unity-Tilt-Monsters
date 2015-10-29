using UnityEngine;
using System.Collections;

public class StaticMotion : MonoBehaviour {

    public Vector2 staticMotion = new Vector2(0, 1);
    public Vector2 enemyMotion = new Vector2(1, 2);
    public float changeMotionInRange = 4f;
    public float changeMotionOnRange = 8f;
    public float endOfLeft = -3.75f;
    public float endOfRight = 3.75f;
    public bool changeSide = false;


    private Rigidbody2D enemyRigidbody;
    private Vector2 movement;
    private bool onCamera = false;
    private bool startMotion = true;


    void FixedUpdate()
    {
        if (gameObject.transform.position.x < endOfLeft ||
                gameObject.transform.position.x > endOfRight)
            ChangeMotion();
     
           EnemyMotion();

    }

    void EnemyMotion()
    {
        if (onCamera)
        {
            if (startMotion)
            {
                startMotion = !startMotion;
                ChangeMotion();
            }
        }
        else 
        {
            movement = new Vector2(staticMotion.x, staticMotion.y);
            GetComponent<Rigidbody2D>().velocity = movement;
        }
       
    }


    void OnBecameVisible()
    {
        print("Static item is Visible!");
        onCamera = true;
    }
    void OnBecameInvisible()
    {
        print("Element stay invisible!");
        Destroy(gameObject);
    }

    void ChangeMotion()
    {
        float randomTime = Random.Range(changeMotionInRange, changeMotionOnRange);

        if (changeSide)
        {
            movement = new Vector2(
            enemyMotion.x,
            enemyMotion.y);
        }
        else
        {
            movement = new Vector2(
              -enemyMotion.x,
               enemyMotion.y);
        }
        changeSide = !changeSide;
        GetComponent<Rigidbody2D>().velocity = movement;
        Invoke("ChangeMotion", randomTime);
    }
    
}
