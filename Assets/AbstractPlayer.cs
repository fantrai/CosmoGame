using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractPlayer : AbstractEntity, IPlayer
{
    private void Awake()
    {
        GameManager.M.player = this;
    }

    protected override void Movement()
    {
        var joystick = GameManager.M.joystick;
        transform.Translate(new Vector2(joystick.Horizontal, joystick.Vertical) * movementSpeed);
        IPlayer.OnMove(transform.position);
    }
}
