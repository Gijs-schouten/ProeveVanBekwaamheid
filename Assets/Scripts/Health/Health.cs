using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int heartsAmount;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    private float _timeLeft = 2;
    private bool _canDamage = true;
    [SerializeField] private KillPlayer _killPlayer;

    void Update()
    {
        if(health > heartsAmount)
        {
            health = heartsAmount;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < heartsAmount)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (!_canDamage)
        {
            _timeLeft -= Time.deltaTime;
            if(_timeLeft <= 0)
            {
                _canDamage = true;
                _timeLeft = 2;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && _canDamage)
        {
            TakeDamage();
            _canDamage = false;
        }
    }

    public void TakeDamage()
    {
        health--;

        if(health == 0)
        {
            _killPlayer.PlayerKiller();
        }

    }

}
