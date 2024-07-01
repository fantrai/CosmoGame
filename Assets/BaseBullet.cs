using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : AbstractBullet
{
    protected override void Movement()
    {
        transform.Translate(Vector2.right * Speed, Space.Self);
        Distance -= Speed;
        if (Distance < 0)
        {
            Destroy(gameObject);
        }
    }
}
