using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable")
        {
            Debug.Log("yeah nice cool woohoo");
            Destroy(other.gameObject);
        }
    }
}
