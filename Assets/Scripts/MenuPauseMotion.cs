using UnityEngine;
using System.Collections;

public class MenuPauseMotion : MonoBehaviour {

    public Vector3 positionTo;
    public int transformSpeed = 5;
    public float moveDelay = 1.0f;

    private Vector2 movement;
    void Update()
    {
        Invoke("move", moveDelay);
        
    }

    private void move() 
    {
        transform.position = Vector3.MoveTowards(transform.position,
                positionTo, transformSpeed * Time.deltaTime);
    }
}
