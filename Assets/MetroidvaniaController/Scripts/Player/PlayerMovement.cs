using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private float timeCurrent;
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    public bool canMove = true;
    public bool shop = false;
    public GameObject shopPanel;
    public GameObject pauseMenu;

    //bool dashAxis = false;

    // Update is called once per frame
    void Update()
    {

        if (shop && Input.GetKeyDown(KeyCode.F))
        {
            canMove = false;
            shopPanel.SetActive(true);
            Cursor.visible = true;
        }

        if (canMove)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0 && pauseMenu.activeSelf)
                {
                    Time.timeScale = timeCurrent;
                }
                else
                {
                    timeCurrent = Time.timeScale;
                    Time.timeScale = 0;
                }
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.Z) && !jump && !dash && !animator.GetBool("IsDashing"))
            {
                animator.SetBool("IsJumping", true);
                jump = true;
                Invoke("canJump", 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.C) && !jump && !dash && !animator.GetBool("IsJumping"))
            {
                animator.SetBool("IsDashing", true);
                horizontalMove = 0;
                Invoke("canDash", 0.2f);
                Invoke("canDash", 0.8f);
            }
            else if (!jump && !dash && !animator.GetBool("IsDashing"))
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            }

            /*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
            {
                if (dashAxis == false)
                {
                    dashAxis = true;
                    dash = true;
                }
            }
            else
            {
                dashAxis = false;
            }
            */
        }
        
        if (shop && Input.GetKeyDown(KeyCode.Escape))
        {
            shopPanel.SetActive(false);
            canMove = true;
            Cursor.visible = false;
        }
    }

    public void OnFall()
    {
        animator.SetBool("IsJumping", true);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
    }

    private void canJump()
    {
        jump = false;
    }

    private void canDash()
    {
        dash = !dash;
        horizontalMove = 0;
    }
}
