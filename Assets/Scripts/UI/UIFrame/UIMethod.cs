using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethod
{
    private static UIMethod instance;
    public static UIMethod GetInstance()
    {
        if (instance == null)
        {
            instance = new UIMethod();
        }
        return instance;
    }

    // 获得Canvas对象
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.LogError("CanvasObj is null");
        }
        return gameObject;
    }

    // 获得单个UI对象
    public GameObject FindObjectInChild(GameObject panel, string name)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.name == name)
            {
                return transform.gameObject;
            }
        }
        Debug.LogWarning($"Can't find {name} in {panel.name}");
        return null;
    }
    
    //从目标对象获取或添加组件
    public T AddOrGetComponent<T>(GameObject obj) where T : Component
    {
        if(obj.GetComponent<T>()!=null)
        {
            return obj.GetComponent<T>();
        }
        else
        {
            return obj.AddComponent<T>();
        }
    }

    //从目标对象的子对象获取或添加组件
    public T GetOrAddSingleComponentInChild<T>(GameObject obj, string name) where T : Component
    {
        Transform[] transforms = obj.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.name == name)
            {
                if (transform.GetComponent<T>() != null)
                {
                    return transform.GetComponent<T>();
                }
                else
                {
                    return transform.gameObject.AddComponent<T>();
                }
            }
        }
        Debug.LogWarning($"Can't find {name} in {obj.name}");
        return null;
    }
}
