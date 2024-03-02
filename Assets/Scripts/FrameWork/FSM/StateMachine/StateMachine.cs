using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class StateMachine : IStateParent
{
    private IState currentState;
    private Dictionary<string, IState> stateDict;

    public StateMachine(IStateBuilder stateBuilder)
    {
        stateDict = new Dictionary<string, IState>();
        if(stateBuilder is null)
        {
            Debug.LogError($"...状态机初始化失败,状态构建器为空.......");
            return;
        }
        for (int i = 0; i < stateBuilder.Count; i++)
        {
            AddState(stateBuilder[i].StateID, stateBuilder[i].StateType);
        }
    }

    public void OnUpdate()=> currentState?.OnUpdate();
    public void OnFixedUpdate()=> currentState?.OnFixedUpdate();
    public IState GetCurrentState()=>currentState;
    public void ChangeState(string toStateID)
    {
        if (!stateDict.ContainsKey(toStateID))
        {
            Debug.LogError($"...切换状态失败,不存在状态ID为{toStateID}的状态.......");
            return;
        }
        if (currentState != null)
        {
            if (currentState == stateDict[toStateID])
            {
                Debug.LogError($"...切换状态失败,状态{toStateID}在运行中.......");
                return;
            }
            currentState.OnExit();
        }
        currentState = stateDict[toStateID];
        currentState.OnEnter();
        Debug.Log($"...切换状态成功,当前状态为{currentState}.......");
    }

    public bool GetState<T>(string stateID, out T state) where T : class, IState, new()
    {
        state=null;
        if (stateDict.TryGetValue(stateID, out IState stateValue))
        {
            if (stateValue is T )
            {
                state = stateValue as T;
                return true;
            }
        }
        return false;   
    }

    private void AddState(string stateID,Type stateType) 
    {
        if (stateDict.ContainsKey(stateID))
        {
            Debug.LogError($"...添加状态失败,已存在状态ID为{stateID}的状态.......");
            return;
        }
        if(stateType==null)
        {
            Debug.LogError($"...添加状态失败,状态类型为空.......");
            return;
        }
        //通过反射创建状态实例
        if(Activator.CreateInstance(stateType) is IState state)
        {
            state.Initialize(this);
            stateDict.Add(stateID, state);
        }
    }

}
