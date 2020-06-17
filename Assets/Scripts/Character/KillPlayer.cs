using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kills the player
/// </summary>
public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    void Update()
    {
        if(transform.position.y < -30)
        {
            PlayerKiller();
        }
    }
   //kills player and loads death screen
    public void PlayerKiller()
    {
        anim.SetBool("isOpen", true);
		GetComponent<PlayerMovement>().enabled = false;
    }

}
