using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    Player player;
    GameObject enemy;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");//enemy
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.transform.position.y > this.transform.position.y) //checking_player_Up_or_Down_of_The_Board
        {
            IFroce froce = target.gameObject.GetComponent<IFroce>();
            if(froce != null)
            {
                froce.GiveFroce();
            }
        }
    }
}
