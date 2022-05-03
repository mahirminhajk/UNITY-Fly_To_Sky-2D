using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{

    [SerializeField] Transform lastBoardPos, board;
    float XMin, XMax;//ymin = 5, ymax = 8.. 

    private void Awake()
    {
        GetXMaxMin();//seting x min and max...
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "board")//geting last board pos //if the last pos is over //spawn new board
        {
            if (target.transform.position == lastBoardPos.transform.position)//we touch the last Board..
            {
                GameObject lastGameobject =  Instantiate(board.gameObject,
                    new Vector2(Random.Range(XMin,XMax), lastBoardPos.transform.position.y + Random.Range(5,8)),
                    Quaternion.identity) as GameObject;
                lastBoardPos = lastGameobject.transform;  //ToDo .. make a function return a GAmeobject 
            }

        }
    }
    private void GetXMaxMin()
    {
        Vector3 cameraBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        XMax = cameraBorder.x + -0.8f;
        XMin = -cameraBorder.x + 0.8f;
    }
}
