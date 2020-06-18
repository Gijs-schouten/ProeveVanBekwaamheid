using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script manages the player's health
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _heartsAmount;
    [SerializeField]
    private Image[] _hearts;
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _emptyHeart;

	[SerializeField] private float iFrames;
    private float _timeLeft;
    private bool _canDamage = true;
    private KillPlayer _killPlayer;

	private void Start() {
		_killPlayer = GetComponent<KillPlayer>();
		_timeLeft = iFrames;
	}

	void Update()
    {
        if(_health > _heartsAmount)
        {
            _health = _heartsAmount;
        }

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _health)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }

            if (i < _heartsAmount)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }

        if (!_canDamage)
        {
            _timeLeft -= Time.deltaTime;
            if(_timeLeft <= 0)
            {
                _canDamage = true;
                _timeLeft = iFrames;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && _canDamage)
        {
            _canDamage = false;
        }
    }

    public void TakeDamage()
    {
		if (_canDamage) {
            _health--;
		}
        
        if(_health == 0)
        {
            _killPlayer.PlayerKiller();
        }

    }

}
