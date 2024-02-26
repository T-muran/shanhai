using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    private static string name = "SettingPanel";
    private static string path = "SettingPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public SettingPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Back").onClick.AddListener(Back);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("SettingPanel OnEnable");
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("SettingPanel OnDisable");
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("SettingPanel OnDestroy");
    }

    private void Back()
    {
        GameController.GetInstance().UIManager.Pop(false);
    }
}
