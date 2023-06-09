using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Damag : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] Slider HPBar;
    public int currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        HPBar.maxValue = maxHealth;
        HPBar.value = HPBar.maxValue;

    }

    protected virtual void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        HPBar.value = currentHealth;
        Debug.Log(currentHealth);

        //if(currentHealth <= 0)
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
