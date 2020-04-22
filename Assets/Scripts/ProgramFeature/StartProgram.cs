using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProgram : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    public void ToggleCanvas()
    {
        if (panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("Open");
                animator.SetBool("Open", !isOpen);
            }
        } 
    }
}
