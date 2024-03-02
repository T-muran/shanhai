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
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Load").onClick.AddListener(Load);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Exit").onClick.AddListener(Exit);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Setting").onClick.AddListener(Setting);
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

    private void Exit()
    {
        GameController.GetInstance().UIManager.Pop(false);
        //退出游戏
        Application.Quit();
    }

    private void Load()
    {
        Scene2 scene2 = new Scene2();
        GameController.GetInstance().SceneControl.LoadScene("Scene2",scene2);
        GameController.GetInstance().UIManager.Pop(true);
        GameController.GetInstance().StateMachine.ChangeState(GameController.GameState.Play.ToString());
    }

    private void Setting()
    {
        GameController.GetInstance().UIManager.Push(new SettingPanel());
    }
}
