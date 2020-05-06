using UnityEngine;
using UnityEngine.UI;

public class CollectCounter : MonoBehaviour
{

    private static int collectedValue = 0;
    Text collected;
    void Start()
    {
        collected = GetComponent<Text>();
    }


    void Update()
    {
        collected.text = "" + collectedValue;
    }
}
