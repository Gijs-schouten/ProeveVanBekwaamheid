using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable")
        {
//            CollectCounter.collectedValue += 1;
            Debug.Log("collected");
            Destroy(other.gameObject);
        }
    }
}
