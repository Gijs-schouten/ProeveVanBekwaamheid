using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script toggle activates a panel
/// </summary>
public class Dis_EnablePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void ToggleActive()
    {
        _panel.SetActive(!_panel.activeSelf);
    }

    
}
