using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : AbstractEntity, IPlayer
{
    int saveLayer = 6;
    int defoultLayer;

    protected List<IShipElement> shipElements = new List<IShipElement>();
    protected Dictionary<EnamMatherials, int> matherials = new Dictionary<EnamMatherials, int>();

    [SerializeField] AbstractShipElement startElement;
    [SerializeField, Min(0)] protected float secondsNotTakeDamage = 0.1f;
    [SerializeField] CircleCollider2D takeMatherialCollider;

    public int MaxCountItemOneType { get; set; }

    private void Start()
    {
        GameManager.M.player = this;
        shipElements.Add(startElement.StartUse(transform));
        defoultLayer = gameObject.layer;
    }

    private void OnEnable()
    {
        IPlayer.OnAddShipElement += AddShipElement;
    }

    private void OnDisable()
    {
        IPlayer.OnAddShipElement -= AddShipElement;
    }

    protected override void Movement()
    {
        var joystick = GameManager.M.joystick;
        transform.Translate(new Vector2(joystick.Horizontal, joystick.Vertical) * movementSpeed, Space.World);
        if (joystick.Direction != Vector2.zero)
        {
            var angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        IPlayer.OnMove(transform.position);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        foreach (var shipElement in shipElements)
        {
            shipElement.TimeAfterCooldown += Time.fixedDeltaTime;
        }
    }

    protected void AddShipElement(IShipElement element)
    {
        shipElements.Add(element);
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

    protected void AddMatherial(IMatherial matherial)
    {
        if (!matherials.ContainsKey(matherial.Matherial))
        {
            matherials.Add(matherial.Matherial, 0);
        }
        if (matherials[matherial.Matherial] < MaxCountItemOneType)
        {
            matherials[matherial.Matherial]++;
            Debug.Log($"добавлено: {matherial.Matherial}");
        }
        if (IPlayer.OnUpdateMatherial != null)
            IPlayer.OnUpdateMatherial(matherial, matherials[matherial.Matherial]);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.IsTouching(takeMatherialCollider))
        {
            if (collision.gameObject.TryGetComponent(out IMatherial takeMatherial))
            {
                AddMatherial(takeMatherial);
                takeMatherial.StartAnim(transform);
            }
        }
    }
}
