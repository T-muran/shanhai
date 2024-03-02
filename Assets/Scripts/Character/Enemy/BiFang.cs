using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiFang : EnemyBase
{
    public enum BiFangState
    {
        Roaming,
        Chasing,
        Attacking,
        Stunned,
        Dead
    }
    public BiFangState currentState;

    void Start()
    {

    }
    void Update()
    {
        base.Move();
    }
}
