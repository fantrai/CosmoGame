using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractEnemy : AbstractEntity, IEnemy
{
    public static float despawnDistance = 30;

   Vector3 targetPos = Vector3.zero;

    private void Start()
    {
        despawnDistance = Camera.main.orthographicSize * 4 * (Screen.width / Screen.height);
    }

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
        targetPos = target;
    }

    protected override void Movement()
    {
        Vector2 pos = targetPos - transform.position;
        var angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(pos.normalized * movementSpeed, Space.World);
        if (Vector2.Distance(targetPos, transform.position) >= despawnDistance)
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
