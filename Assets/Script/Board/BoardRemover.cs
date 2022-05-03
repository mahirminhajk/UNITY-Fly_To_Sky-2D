using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRemover : MonoBehaviour
{ //to if the player pass and the enemy pass please destory the board
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "board")
        {
            Destroy(target.gameObject);
        }
    }
}
