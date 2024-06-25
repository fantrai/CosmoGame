using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour, IEntity
{
    [SerializeField] protected float movementSpeed;
 
    protected virtual void FixedUpdate()
    {
        Movement();
    }

    protected abstract void Movement();
}
