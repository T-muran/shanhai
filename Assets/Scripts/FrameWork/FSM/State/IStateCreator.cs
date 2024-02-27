using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateCreator 
{
    string StateID { get; }
    Type StateType { get; }
}
