using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{   
    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnEnable()
    {
        IPlayer.OnMove += MoveOnPlayer;
    }
    private void OnDisable()
    {
        IPlayer.OnMove -= MoveOnPlayer;
    }

    void MoveOnPlayer(Vector3 pos)
    {
        transform.position = pos + startPos;
    }
}
