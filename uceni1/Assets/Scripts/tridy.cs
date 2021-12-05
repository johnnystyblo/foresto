using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hrac // blueprint pro postavy
{
    int _health;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    int mana;
    int damage;
    string name;

    public Hrac(int health, int mana, int damage, string name)
    {

        Health = health;
        this.mana = mana;
        this.damage = damage;
        this.name = name;
    }
    public void Info()
    {
        Debug.Log("Health is: " + Health);
        Debug.Log("Mana is: " + mana);
        Debug.Log("Damage is: " + damage);
        Debug.Log("Name is: " + name);

    }
    /*
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public int GetHealth()
    {
        return health;
    }
    */
}
