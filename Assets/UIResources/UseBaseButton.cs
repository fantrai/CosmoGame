using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseBaseButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI butt;

    private void Start()
    {
        IPlayerBase.OnUpdateStatus += UpdateButton;
    }

    private void OnDestroy()
    {
        IPlayerBase.OnUpdateStatus -= UpdateButton;
    }

    void UpdateButton(EnumStatusPlayerBase status)
    {
        switch (status)
        {
            case EnumStatusPlayerBase.None:
                gameObject.gameObject.SetActive(true);
                butt.text = "развернуть базу";
                break;

            case EnumStatusPlayerBase.Creating:
                gameObject.gameObject.SetActive(false);
                break;

            case EnumStatusPlayerBase.Stay:
                gameObject.gameObject.SetActive(true);
                butt.text = "к базе";
                break;

            case EnumStatusPlayerBase.Destrpyed:
                butt.text = "починить базу";
                break;

            case EnumStatusPlayerBase.Unknown:
                gameObject.gameObject.SetActive(false);
                break;
        }
    }

    public void Click()
    {
        if (IPlayerBase.Status == EnumStatusPlayerBase.None)
        {
            IPlayer.OnCreateBase();
        }
    }
}
