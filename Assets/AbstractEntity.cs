using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour, IEntity
{
    [SerializeField, Min(0)] protected float movementSpeed = 0.1f;
    [SerializeField, Min(1)] protected int hp = 1;
    [SerializeField, Min(1)] protected int touchDamage = 1;
    [SerializeField, Min(0)] protected int defence = 0;
    [SerializeField] Collider2D touchCollider;
    protected int Hp { get => hp;
        set 
        {
            hp = value;
            if (hp <= 0)
            {
                StartCoroutine(Dead());
            }
        } 
    }

    protected virtual void FixedUpdate()
    {
        Movement();
    }

    protected abstract void Movement();

    protected IEnumerator Dead()
    {
        yield return new WaitForFixedUpdate();
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= defence;
        if (damage > 0)
        {
            Hp -= damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouching(touchCollider))
        {
            if (collision.gameObject.TryGetComponent<IEntity>(out IEntity entity))
            {
                entity.TakeDamage(touchDamage);
            }
        }
    }
}
