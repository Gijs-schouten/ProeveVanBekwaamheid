using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Checks if the distance is short enough to the player. Then shows a button for the program question
/// </summary>
public class GetDistance : MonoBehaviour
{
    [SerializeField] private List<GameObject> _distance;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _maxDistance;
     private float _vDistance;


    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _button;


    public int _index = 0;
    
    void Start()
    {
        FetchDistance();
    }
    //gets distance from player
    public void FetchDistance()
    {
        _gameObject = _distance[_index];
    }
    //gets to the next point
   public void NextDistance()
    {

        _index++;
    }

    void Update()
    {
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        _vDistance = Vector2.Distance(_gameObject.transform.position, _player.transform.position);
        _button.SetActive(_vDistance <= _maxDistance);
    }
}
