using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (M != null) Destroy(this.gameObject);
        M = this;
    }

    public static GameManager M { get; private set; }

    public Joystick joystick;
    public IPlayer player;
}
