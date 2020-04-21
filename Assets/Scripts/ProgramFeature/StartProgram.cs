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
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        } 
    }

    public void RightAnswer()
    {
        print("you are good");
    }

    public void WrongAnswer()
    {
        print("you are bad");
    }
}
