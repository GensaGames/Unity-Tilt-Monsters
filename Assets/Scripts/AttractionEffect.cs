using UnityEngine;
using System.Collections;

public class AttractionEffect : MonoBehaviour {

    public Vector2 walkSpeed = new Vector2(8, 4);
    public Vector2 attractionMove = new Vector2(0, 1);
    public bool makeFullControll = true;
    

    private Vector2 movement;
    private bool checkTrigger = false;
    private GameObject collisionObject;


    void Start() 
    {
        GetComponent<Rigidbody2D>().velocity = attractionMove;
    }



    void Update()
    {
        if (checkTrigger)
        PlayerWalk();

    }


    void FixedUpdate()
    {
        if (checkTrigger)
        {
            collisionObject.GetComponent<Rigidbody2D>().velocity = movement;
        }    
    }


    private void PlayerWalk()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = 0f;

        if (makeFullControll)
            inputY = Input.GetAxis("Vertical");

            movement = new Vector2(
                 inputX,
                 inputY);        

    }



    void OnTriggerEnter2D(Collider2D collider2D)
    {        
        

        if (collider2D.gameObject.tag == "Player")
        {
            collisionObject = collider2D.gameObject;

            checkTrigger = true;
            collisionObject.GetComponent<PlayerController>().enabled = false;
        }

    }
    void OnTriggerExit2D(Collider2D collider2D) {


        if (collider2D.gameObject.tag == "Player")
        {
            collisionObject = collider2D.gameObject;

            checkTrigger = false;
            collisionObject.GetComponent<PlayerController>().enabled = true;
        }

    }

}
