using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController character_Controller; ///Character Controller is a built in function unity offers that you can add to your player. Its function is to move the character around the enviroment 
        ///Our GameObject(CharacterController) Our Target (character_Controller)

    private Vector3 move_Direction = Vector3.zero; ///Built in function that Unity provides to move the direction of the player
    
    
    public float jump_Speed = 8.0f; ///Since both Jump speed and speed are public variables you can edit them inside Unity
    public float speed = 6.0f;   
    
    private float gravity = 20f;
    private float vertical_Velocity;


    public class Axis
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";
    }

    public class MouseAxis
    {
        public const string MOUSE_X = "Mouse X";
        public const string MOUSE_Y = "Mouse Y";
    }




    void Start()
    {
        character_Controller = GetComponent<CharacterController>(); //Starts the controller script here
    }

    void Update()
    {
        
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0.0f,Input.GetAxis(Axis.VERTICAL));   ///This gets the direction of the Horizontal and Vertical axis which will move the charcter
        move_Direction = transform.TransformDirection(move_Direction);  ///Transform the Direction of the built in (move_Direction) funciton provided by Unity
        move_Direction *= speed * Time.deltaTime;   ///Mutliples speed *time.deltaTime

        ApplyGravity();   ///Starts the Void ApplyGravity function to all the user inputs.

        character_Controller.Move(move_Direction);  ///Moves the character in the direction the users requests 

    }

    void ApplyGravity()   ///ApplyGravity function starts here
    {

        vertical_Velocity -= gravity * Time.deltaTime;  ///Gravity times Time.deltatime.

        // jump
        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;  ///Moves the character if PlayerJump is triggered.

    } 

    void PlayerJump()   ///PlayerJump Function
    {

        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))  ///If the characterController is Grounded and the the inputKey is being pressed(space bar on keyboard)
        {
            vertical_Velocity = jump_Speed;   ///Then excute the vertical velocity of the jump speed
        }

    }

}
