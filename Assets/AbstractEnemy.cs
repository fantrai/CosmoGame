using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbstractEnemy : AbstractEntity
{
    public const float DESPAWN_DISTANCE = 30;

    Vector3 targetPos = Vector3.zero;

    private void OnEnable()
    {
        IPlayer.OnMove += TargetUpdate;
    }

    private void OnDisable()
    {
        IPlayer.OnMove -= TargetUpdate;
    }

    void TargetUpdate(Vector3 target)
    {
        targetPos = (target - transform.position).normalized;
    }

    protected override void Movement()
    {
        transform.Translate(targetPos * movementSpeed);
        if (Vector2.Distance(transform.position, targetPos) >= DESPAWN_DISTANCE)
        {
            Despawn();
        }
    }

    protected void Despawn()
    {
        StartCoroutine(base.Dead());
    }

    protected override IEnumerator Dead()
    {
        GetComponents<DropMatherial>().ToList().ForEach(p => p.Drop());
            return base.Dead();
    }
}
