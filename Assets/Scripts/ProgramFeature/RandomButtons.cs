using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomButtons : MonoBehaviour
{
   [SerializeField] private List <GameObject> _buttons;
   [SerializeField] private List<GameObject> _places;

    List<int> list = new List<int>();

    public void SetPosition()
    {
        var randomList = new List <GameObject> (_places);
        foreach (GameObject button in _buttons)
        {
            var random = randomList[Random.Range(0, randomList.Count)];
            randomList.Remove(random);
           button.transform.position = random.transform.position;
        } 
    }
}
