using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    [SerializeField] private List<GameObject> _distance;
    [SerializeField] private GameObject _gameobject;
    [SerializeField] private float _maxDistance;
     private float _vDistance;


    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _button;


    public int _index = 0;
    
    void Start()
    {
        FetchDistance();
    }

    public void FetchDistance()
    {
        _gameobject = _distance[_index];
    }

   public void NextDistance()
    {

        _index++;
    }

    void Update()
    {
        _vDistance = Vector2.Distance(_gameobject.transform.position, _player.transform.position);
        _button.SetActive(_vDistance <= _maxDistance);
    }
}
