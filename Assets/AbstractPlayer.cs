using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractPlayer : AbstractEntity, IPlayer
{
    const string savelayerName = "SavePlayer";
    const string defoultlayerName = "Player";

    public List<IShipElement> ShipElements { get; set; } = new List<IShipElement>();
    [SerializeField] AbstractShipElement startElement;
    [SerializeField, Min(0)] protected float secondsNotTakeDamage = 0.1f;

    private void Awake()
    {
        GameManager.M.player = this;
        ShipElements.Add(startElement.StartUse(transform));
    }

    protected override void Movement()
    {
        var joystick = GameManager.M.joystick;
        transform.Translate(new Vector2(joystick.Horizontal, joystick.Vertical) * movementSpeed);
        IPlayer.OnMove(transform.position);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        foreach (var shipElement in ShipElements)
        {
            shipElement.TimeAfterCooldown += Time.fixedDeltaTime;
        }
    }

    public void AddShipElement(IShipElement element)
    {
        ShipElements.Add(element);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        gameObject.layer = SortingLayer.NameToID(savelayerName);
    }

    protected IEnumerator NotDamage()
    {
        gameObject.layer = SortingLayer.NameToID(savelayerName);
        yield return new WaitForSeconds(secondsNotTakeDamage);
        gameObject.layer = SortingLayer.NameToID(defoultlayerName);
    }
}
