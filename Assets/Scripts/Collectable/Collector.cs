using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private Player _player;
    void Start()
    {
        _player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable")
        {
            _player.CollectItem(1);
            Destroy(other.gameObject);
        }    
    }
}
