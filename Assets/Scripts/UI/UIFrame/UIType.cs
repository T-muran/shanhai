using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string path;
    public string Path
    {
        get => path;
    }
    private string name;
    public string Name
    {
        get => name;
    }
    /// <summary>
    /// 获得UI信息
    /// </summary>
    /// <param name="uiPath">路径</param>
    /// <param name="uiName">名称</param>
    public UIType(string uiPath, string uiName)
    {
        path = uiPath;
        name = uiName;
    }
}
