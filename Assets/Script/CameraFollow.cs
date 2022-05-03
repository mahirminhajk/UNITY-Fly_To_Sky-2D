using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if(player != null)//for testing....
        {
            if(player.transform.position.y > this.transform.position.y)
            {
                this.transform.position = new Vector3(transform.position.x, player.transform.position.y);
            }//else - do_not_follow_or_die_the_player
        }
    }
}
