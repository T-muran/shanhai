using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    // 存储UI面板的栈
    public Stack<BasePanel> stackUI;
    // 存储Panel的字典
    public Dictionary<string, GameObject> dictUIObject;
    public GameObject canvasObj;
    // 单例模式
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManager is null");
        }
        return instance;
    }

    public UIManager()
    {
        instance = this;
    }

    public GameObject GetSingleObject(UIType uiType)
    {
        if (dictUIObject.ContainsKey(uiType.Path))
        {
            return dictUIObject[uiType.Path];
        }
        if (canvasObj == null)
        {
            //待优化
            Debug.LogError("CanvasObj is null");
            return null;
        }
        GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(uiType.Path), canvasObj.transform) as GameObject;
        return uiObject;
    }

    /// <summary>
    /// 往StackUI中压入一个Panel
    /// </summary>
    /// <param name="panel">目标Panel</param>

    public void Push(BasePanel panel)
    {
        Debug.Log($"Push {panel.uiType.Name}");

        if (stackUI.Count > 0)
        {
            stackUI.Peek().OnDisable();
        }

        GameObject uiObject = GetSingleObject(panel.uiType);
        dictUIObject.Add(panel.uiType.Name, uiObject);
        panel.ActiceObj = uiObject;

        if (stackUI.Count == 0)
        {
            stackUI.Push(panel);
        }
        else
        {
            if(stackUI.Peek().uiType.Name != panel.uiType.Name)
            {
                stackUI.Push(panel);
            }
        }

        panel.OnStart();
    }

    /// <summary>
    /// 出栈
    /// </summary>
    /// <param name="isLoad">isLoad为true时，Pop全部，else Pop栈顶</param>

    public void Pop(bool isLoad)
    {
        //栈清空
        if(isLoad==true)
        {
            while(stackUI.Count>0)
            {
                stackUI.Peek().OnDisable();
                stackUI.Peek().OnDestroy();
                GameObject.Destroy(dictUIObject[stackUI.Peek().uiType.Name]);
                dictUIObject.Remove(stackUI.Peek().uiType.Name);
                stackUI.Pop();
            }
        }
        //弹出栈顶
        else{
            if(stackUI.Count>0)
            {
                stackUI.Peek().OnDisable();
                stackUI.Peek().OnDestroy();
                GameObject.Destroy(dictUIObject[stackUI.Peek().uiType.Name]);
                dictUIObject.Remove(stackUI.Peek().uiType.Name);
                stackUI.Pop();

                if(stackUI.Count>0)
                {
                    stackUI.Peek().OnEnable();
                }
            }
        }
    }
}
