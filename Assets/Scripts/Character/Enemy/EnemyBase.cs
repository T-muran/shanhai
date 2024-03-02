using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int attackPower;
    public float moveSpeed;
    public float attackRange;
    public float chaseRange;
    public float stunTime;
    public StateMachine stateMachine;

    public virtual void Move(){
        
    }

}
