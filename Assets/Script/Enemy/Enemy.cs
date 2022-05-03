using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IFroce
{
    Rigidbody2D rigi;
    [SerializeField] float froce = 100f, movementSpeed = 5f;//force

    //enemy Ai
    BoardColl boardColl;
    bool TouchedTheBoard = false;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        boardColl = FindObjectOfType<BoardColl>();
    }

    private void Update()
    {
        //enmy ai
        if (rigi.velocity.y <= 0f)
        {
            TouchedTheBoard = true;
        }
        if (TouchedTheBoard && boardColl.SBoardCollCount() > 1)
        {//timeToScan
            GameObject nearBoard;
            while (true)
            {
                nearBoard = boardColl.LastBoardInfo();//savethelastBoard
                if (transform.position.y > nearBoard.transform.position.y)
                {
                    break;
                }
                boardColl.LastBoard();//pop the last board
            }
            Debug.DrawLine(transform.position, nearBoard.transform.position, Color.red);
            Vector2 targetPos = new Vector2(nearBoard.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
        }
        
    }

    public void GiveFroce()//Interface - IFroce
    {
        rigi.velocity = new Vector2(0, 10) * (Time.deltaTime * froce);
        TouchedTheBoard = false;//stopTheScan
        boardColl.ClearStack();
    }
}
