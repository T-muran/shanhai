using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    Load,
    Play,
    Pause,
    Fail,
}

public class GameController : MonoBehaviour
{
    private UIManager uIManager;
    public UIManager UIManager { get => uIManager; }
    private SceneControl sceneControl;
    public SceneControl SceneControl { get => sceneControl; }
    private static GameController instance;
    private StateMachine stateMachine;
    public StateMachine StateMachine { get => stateMachine; }

    public static GameController GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("GameController is null");
        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        uIManager = new UIManager();
        sceneControl = new SceneControl();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        #region 初始化状态机
        StateBuilder stateBuilder = new StateBuilder();
        stateBuilder.AddState<LoadState>(GameState.Load.ToString());
        stateBuilder.AddState<PlayState>(GameState.Play.ToString());
        stateBuilder.AddState<FailState>(GameState.Fail.ToString());
        stateMachine = new StateMachine(stateBuilder);
        stateMachine.ChangeState(GameState.Load.ToString());
        #endregion

        //UI
        uIManager.canvasObj = UIMethod.GetInstance().FindCanvas();

        Scene1 scene1 = new Scene1();
        SceneControl.dictScene.Add(scene1.sceneName, scene1);

        #region 推入第一个面板
        uIManager.Push(new StartPanel());
        #endregion

    }
}

#region 状态
public class LoadState : StateBase
{
    protected override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("LoadState OnEnter");
    }
}

public class PlayState : StateBase
{
    protected override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("PlayState OnEnter");
    }
}

public class FailState : StateBase
{
    protected override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("FailState OnEnter");
    }
}
#endregion
