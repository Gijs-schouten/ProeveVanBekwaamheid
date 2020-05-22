using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PauseMenu _pauseMenu;



    void Update()
    {
        if(transform.position.y < -30)
        {
            PlayerKiller();
        }
    }

    public void PlayerKiller()
    {
        anim.SetBool("isOpen", true);
    }

}
