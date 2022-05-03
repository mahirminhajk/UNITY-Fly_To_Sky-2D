using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IFroce
{
    Rigidbody2D rigi;
    Animator anim;

    [SerializeField] float froce = 100f, movementSpeed = 5f;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
        anim.SetBool("isJumping", IsJumping());
    }

    public void GiveFroce()//Interface - IFroce
    {
        rigi.velocity = new Vector2(0, 10) * (Time.deltaTime * froce);
    }

    private void PlayerMovement()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if(horizontalAxis > 0)//right
        {
            transform.position += new Vector3(movementSpeed, 1, 0) * Time.deltaTime;
        }
        else if(horizontalAxis < 0)//left
        {
            transform.position += new Vector3(-movementSpeed, 1, 0) * Time.deltaTime;
        }
    }

    private bool IsJumping()//for animation //boolen name:isJumping;
    {
        float playervelocity = rigi.velocity.y;
        if (playervelocity > 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
