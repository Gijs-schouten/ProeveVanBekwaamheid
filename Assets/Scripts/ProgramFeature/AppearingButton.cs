using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingButton : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance;
    private float _distance;

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _button;


    void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        _button.SetActive(_distance <= _maxDistance);
    }
}
