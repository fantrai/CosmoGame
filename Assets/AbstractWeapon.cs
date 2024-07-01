using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : AbstractShipElement
{
    [SerializeField] AbstractBullet bulletPrefab;

    protected override void Effect()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
