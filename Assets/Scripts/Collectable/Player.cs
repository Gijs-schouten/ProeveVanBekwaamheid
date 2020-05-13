using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _collected = 0;

    public Action<int> CollectedValueChanged;

    public void CollectItem(int collect)
    {
        _collected += collect;

        if (CollectedValueChanged != null)
        {
            CollectedValueChanged(_collected);
        }
    }
    
}
