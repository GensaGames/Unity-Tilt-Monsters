using UnityEngine;
using System.Collections;

public class MainMotions : MonoBehaviour {

    public Vector2 coinMotion = new Vector2(0, 150);
    private Vector2 movement;


    void FixedUpdate()
    {
        movement = new Vector2(
            coinMotion.x * Time.deltaTime,
            coinMotion.y * Time.deltaTime);

        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
