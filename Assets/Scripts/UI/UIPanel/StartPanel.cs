using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "StartPanel";
    public static readonly UIType uIType = new UIType(name, path);

    public StartPanel() : base(uIType)
    {
        
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Back").onClick.AddListener(Back);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Load").onClick.AddListener(Load);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("StartPanel OnEnable");
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("StartPanel OnDisable");
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("StartPanel OnDestroy");
    }

    private void Back()
    {
        GameController.GetInstance().UIManager.Pop(false);
        //退出游戏
        Application.Quit();
    }

    private void Load()
    {
        Scene2 scene2 = new Scene2();
        GameController.GetInstance().SceneControl.LoadScene(scene2.sceneName, scene2);
    }
}
