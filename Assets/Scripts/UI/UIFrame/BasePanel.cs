using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;

    /// <summary>
    /// panel在场景中对应的物体
    /// </summary>
    public GameObject ActiceObj;
    public BasePanel(UIType uiType)
    {
        this.uiType = uiType;
    }

    public virtual void OnStart()
    {
        Debug.Log($"OnStart:{uiType.Name}");
    }
    
    public virtual void OnEnable(){

    }

    public virtual void OnDisable(){
    
    }

    public virtual void OnDestroy(){
    
    }
    }
