using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 walkSpeed = new Vector2(8, 4);
    public bool makeFullControll = false;

    private Vector2 movement;

  void Update()
  {
      PlayerWalk();

  }

  void FixedUpdate()
  {
    
    GetComponent<Rigidbody2D>().velocity = movement;
  }


  private void PlayerWalk() {

      float inputX = Input.GetAxis("Horizontal");
      float inputY = 0f;

      if (makeFullControll)      
          inputY = Input.GetAxis("Vertical");

      
      if (walkSpeed.y > 0 || walkSpeed.x > 0)
      {
          movement = new Vector2(
              walkSpeed.x * inputX,
              walkSpeed.y * inputY);
      }
  
  }

}
