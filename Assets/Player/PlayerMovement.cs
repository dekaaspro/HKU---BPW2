using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool characterMoving = false;

    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (controller.playerJumping == false)
        {
            anim.SetBool("isJumping", true);
        } else if (controller.playerJumping == true)
        {
            anim.SetBool("isJumping", false);
        }


        if (Input.GetButtonDown("Horizontal"))
        {
            characterMoving = true;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            characterMoving = false;
        }

        MovingAnimCheck();

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetTrigger("takeOff");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }



        //exit button
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void MovingAnimCheck()
    {
        if(characterMoving == true)
        {
            anim.SetBool("isRunning", true);
        } else if(characterMoving == false)
        {
            anim.SetBool("isRunning", false);
        }
    }
}