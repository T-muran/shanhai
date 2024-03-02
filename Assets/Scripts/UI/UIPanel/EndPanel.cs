using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : BasePanel
{
    private static string name = "EndPanel";
    private static string path = "EndPanel";
    public static readonly UIType uIType = new UIType(name, path);

    public EndPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "MainMenu").onClick.AddListener(Mainmenu);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiceObj, "Exit").onClick.AddListener(Exit);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("EndPanel OnEnable");
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("EndPanel OnDisable");
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("EndPanel OnDestroy");
    }

    private void Exit()
    {
        GameController.GetInstance().UIManager.Pop(false);
        //ÍË³öÓÎÏ·
        Application.Quit();
    }

    private void Mainmenu()
    {
        GameController.GetInstance().UIManager.Pop(false);
        GameController.GetInstance().UIManager.Push(new StartPanel());
    }
}
