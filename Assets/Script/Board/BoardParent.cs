using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardParent : MonoBehaviour
{
    [SerializeField] BoardSpawner[] boardSpawners = new BoardSpawner[2];
    [SerializeField] BoardRemover[] boardRemover = new BoardRemover[2];

    private void Awake()
    {
        for(int i = 0; i < boardSpawners.Length; i++) //false active in the start
        {
            boardSpawners[i].gameObject.SetActive(false);
            boardRemover[i].gameObject.SetActive(false);
        }
        BoardController(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            BoardController(true);
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            BoardController(false);
        }
    }

    private void BoardController(bool value)//true - playerfirst //false - enemy first
    {
        boardSpawners[0].gameObject.SetActive(value);
        boardSpawners[1].gameObject.SetActive(!value);
        boardRemover[1].gameObject.SetActive(value);
        boardRemover[0].gameObject.SetActive(!value);
    }
}
