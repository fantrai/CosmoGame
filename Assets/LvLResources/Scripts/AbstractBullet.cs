using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour, IBullet
{
    public int Damage { get; set; } = 1;
    public float Speed { get; set; } = 1f;
    public int Piercing { get; set; } = 0;
    public float Distance { get; set; } = 30;

    protected void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IEnemy enemy))
        {
            enemy.TakeDamage(Damage);
            Piercing--;
            if (Piercing < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    abstract protected void Movement();
}
