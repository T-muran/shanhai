using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateBuilder 
{
    protected struct StateCreator : IStateCreator
    {
        public string StateID { get; }
        public Type StateType { get; }
        public StateCreator(string stateID, Type stateType)
        {
            StateID = stateID;
            StateType = stateType;
        }
    }
    int Count { get; }

    IStateCreator this[int index] { get; }
}
