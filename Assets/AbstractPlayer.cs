using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractPlayer : AbstractEntity, IPlayer
{
    int saveLayer = 6;
    int defoultLayer;

    public List<IShipElement> ShipElements { get; set; } = new List<IShipElement>();

    int IPlayer.Iron { get; set; } = 0;
    int IPlayer.Plastic { get; set; } = 0;
    int IPlayer.Aluminum { get; set; } = 0;
    int IPlayer.Tungsten { get; set; } = 0;
    int IPlayer.FuelCell { get; set; } = 0;
    int IPlayer.EnergyBattery { get; set; } = 0;
    int IPlayer.SolarPlate { get; set; } = 0;
    int IPlayer.ControlUnit { get; set; } = 0;
    int IPlayer.LongAntenna { get; set; } = 0;
    int IPlayer.Copper { get; set; } = 0;
    int IPlayer.Gold { get; set; } = 0;

    [SerializeField] AbstractShipElement startElement;
    [SerializeField, Min(0)] protected float secondsNotTakeDamage = 0.1f;

    private void Awake()
    {
        GameManager.M.player = this;
        ShipElements.Add(startElement.StartUse(transform));
        defoultLayer = gameObject.layer;
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
        StartCoroutine(NotDamage());
    }

    protected IEnumerator NotDamage()
    {
        gameObject.layer = saveLayer;
        yield return new WaitForSeconds(secondsNotTakeDamage);
        gameObject.layer = defoultLayer;
    }

    void IPlayer.AddShipElement(IShipElement element)
    {
        throw new NotImplementedException();
    }
}
