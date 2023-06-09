using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public int hp;

    public UnityEvent OnDied;
    public UnityEvent<int> OnDamaged;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp < 0) 
            hp = 0;
        OnDamaged?.Invoke(hp);
        if (hp == 0)
            Die();
    }

    public void Die()
    {
        OnDied?.Invoke();
        GameManager.Pool.Release(gameObject);
    }
}
