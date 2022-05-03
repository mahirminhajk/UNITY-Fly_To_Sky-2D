using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColl : MonoBehaviour
{
    private GameObject Board;
    Stack<GameObject> S_BoardColl = new Stack<GameObject>();


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "board")
        {
            Board = target.gameObject;
            S_BoardColl.Push(Board);
        }
    }

    public GameObject LastBoard()
    {
        return S_BoardColl.Pop();
    }

    public GameObject LastBoardInfo()
    {
        return S_BoardColl.Peek();
    }

    public int SBoardCollCount()
    {
        return S_BoardColl.Count + 1;
    }

    public void ClearStack()
    {
        S_BoardColl.Clear();
    }
}
