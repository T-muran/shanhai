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
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiceObj).interactable = true;
    }

    public virtual void OnEnable()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiceObj).interactable = true;
    }

    public virtual void OnDisable()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiceObj).interactable = false;
    }

    public virtual void OnDestroy()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiceObj).interactable = false;
    }
}
