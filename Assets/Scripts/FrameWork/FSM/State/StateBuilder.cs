using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBuilder : IStateBuilder
{
    private List<IStateBuilder.StateCreator> stateCreators;
    int IStateBuilder.Count => stateCreators.Count;

    public StateBuilder()
    {
        stateCreators = new List<IStateBuilder.StateCreator>();
    }

    IStateCreator IStateBuilder.this[int index] => stateCreators[index];

    public void AddState<T>(string stateID) where T : IState, new()
    {
        stateCreators.Add(new IStateBuilder.StateCreator(stateID, typeof(T)));
    }
}