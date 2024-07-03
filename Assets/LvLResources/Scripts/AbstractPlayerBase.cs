using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerBase : MonoBehaviour, IPlayerBase
{
    [SerializeField] CircleCollider2D playerContactCollider;
    protected IPlayer player;

    static float timeCreatePerSecond = 10;

    private void Start()
    {
        StartCoroutine(CreateBase());
    }

    IEnumerator CreateBase()
    {
        NewStatus(EnumStatusPlayerBase.Creating);
        float lateTime = 0;
        IPlayerBase.OnUpdateBaseProgression(lateTime, timeCreatePerSecond, "создание базы");
        do
        {
            yield return new WaitForSeconds(1);
            lateTime++;
            IPlayerBase.OnUpdateBaseProgression(lateTime, timeCreatePerSecond, "создание базы");
        } while (lateTime < timeCreatePerSecond);
        playerContactCollider.enabled = true;
        NewStatus(EnumStatusPlayerBase.Unknown);
    }

    protected void NewStatus(EnumStatusPlayerBase status)
    {
        IPlayerBase.Status = status;
        IPlayerBase.OnUpdateStatus(status);
    }

    public void BaseMenu()
    {
        throw new System.NotImplementedException();
    }

    public void CreateMenu()
    {
        throw new System.NotImplementedException();
    }

    public void StartRepair()
    {
        throw new System.NotImplementedException();
    }

    public void StartTeleport()
    {
        throw new System.NotImplementedException();
    }

    public void UpgradeMenu()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerBase.BaseMenu()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerBase.StartRepair()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerBase.StartTeleport()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerBase.CreateMenu()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerBase.UpgradeMenu()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(playerContactCollider))
        {
            if (collision.TryGetComponent(out IPlayer pl))
            {
                NewStatus(EnumStatusPlayerBase.Stay);
                player = pl;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.IsTouching(playerContactCollider))
        {
            NewStatus(EnumStatusPlayerBase.Unknown);
            player = null;
        }
    }
}
