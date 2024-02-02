using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl
{
    public Dictionary<string, SceneBase> dictScene;
    private static SceneControl instance;
    public static SceneControl GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("SceneControl is null");
        }
        return instance;
    }

    public void LoadScene(string sceneName, SceneBase sceneBase)
    {
        if (!dictScene.ContainsKey(sceneName))
        {
            dictScene.Add(sceneName, sceneBase);
        }

        if (dictScene.ContainsKey(SceneManager.GetActiveScene().name))
        {
            dictScene[SceneManager.GetActiveScene().name].ExitScene();
        }
        else
        {
            Debug.LogWarning($"Scene {SceneManager.GetActiveScene().name} is not in dictScene");
        }

        #region Pop()掉当前场景的所有UI
        GameController.GetInstance().UIManager.Pop(true);
        #endregion
        SceneManager.LoadScene(sceneName);
        sceneBase.EnterScene();
    }
}
