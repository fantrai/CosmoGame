using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : AbstractEntity, IPlayer
{
    static int saveLayer = 6;
    static int defoultLayer;

    protected List<IShipElement> shipElements = new List<IShipElement>();
    protected Dictionary<EnumMatherials, int> matherials = new Dictionary<EnumMatherials, int>();

    [SerializeField] AbstractShipElement startElement;
    [SerializeField, Min(0)] protected float secondsNotTakeDamage = 0.1f;
    [SerializeField] CircleCollider2D takeMatherialCollider;
    [SerializeField] AbstractPlayerBase playerBasePrefab;
 
    public int MaxCountItemOneType { get; set; } = 100;
    Dictionary<EnumMatherials, int> IPlayer.Matherials { get => matherials; }

    private void Start()
    {
        GameManager.M.player = this;
        shipElements.Add(startElement.StartUse(transform));
        defoultLayer = gameObject.layer;
    }

    private void OnEnable()
    {
        IPlayer.OnAddShipElement += AddShipElement;
        IPlayer.OnCreateBase += CreateBase;
    }

    private void OnDisable()
    {
        IPlayer.OnAddShipElement -= AddShipElement;
        IPlayer.OnCreateBase -= CreateBase;
    }

    void CreateBase()
    {
        if (IPlayerBase.Status == EnumStatusPlayerBase.None)
        {
            Instantiate(playerBasePrefab, transform.position, playerBasePrefab.transform.rotation);
        }
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
