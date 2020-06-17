using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script plays animation for the Program Panel
/// </summary>
public class StartProgram : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    public void ToggleCanvas()
    {
        if (_panel != null)
        {
            Animator animator = _panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("Open");
                animator.SetBool("Open", !isOpen);
            }
        } 
    }

    
}
