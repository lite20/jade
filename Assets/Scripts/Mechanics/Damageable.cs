using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// int is the damage taken
[System.Serializable]
public class HurtEvent : UnityEvent<int>{}

public class Damageable : MonoBehaviour
{
    public HurtEvent OnHurt;

    public UnityEvent OnBreak;

    public int health = 100;
    public int maxHealth = 100;

    public void Start()
    {
        if (OnHurt == null) OnHurt = new HurtEvent();
        if (OnBreak == null) OnBreak = new UnityEvent();
    }

    public void Damage(int damage)
    {
        OnHurt.Invoke(damage);

        if (damage >= health)
            OnBreak.Invoke();
        else
            health -= damage;
    }
}
