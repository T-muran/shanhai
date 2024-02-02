using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private UIManager uIManager;
    public UIManager UIManager { get => uIManager; }
    private SceneControl sceneControl;
    public SceneControl SceneControl { get => sceneControl; }
    private static GameController instance;

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
        uIManager.canvasObj = UIMethod.GetInstance().FindCanvas();

        #region 推入第一个面板
        uIManager.Push(new StartPanel());
        #endregion
    }
}
