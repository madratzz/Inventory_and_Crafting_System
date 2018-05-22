//----------------------------------------------
// GAME SCENE MANAGER
// Copyright © RAZA BUTT
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExtendedUnityEngine;

public class GameSceneManager : MonoBehaviour
{

    //Singleton Refference
    public static GameSceneManager instance;


    private void Awake()
    {
        #region Make Singleton
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
        #endregion

        //ForceName
        this.name = "[MANAGER]GAME_SCENE_MANAGER";

        //Check Tag
        if (!this.gameObject.CompareTag("Manager"))
        {
            XDebug.LogErrorRed(this.name + "'s Tag is not set to Manager", "!!!ERROR!!!");
        }
    }


    /// <summary>
    /// Loads Level of specified SceneIndex
    /// </summary>
    /// <param name="sceneIndex">Index of Scene as in Build Settings</param>
    public void LoadScene(int sceneIndex)
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Loading Scene: " + sceneIndex);
        }
        SceneManager.LoadScene(sceneIndex);
    }


    /// <summary>
    /// Loads Level of specified SceneName
    /// </summary>
    /// <param name="sceneName">Name of Scene as in Build Settings</param>
    public void LoadScene(string sceneName)
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Loading Scene: " + sceneName);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(int sceneIndex)
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Loading SceneAsync: " + sceneIndex);
        }
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void LoadSceneAsync(string sceneName)
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Loading SceneAsync: " + sceneName);
        }
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ReloadScene()
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Reloading Scene: " + SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadSceneAsync()
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Reloading Scene Async: " + SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        if (DebugManager.instance.isManagerDebugMode)
        {
            XDebug.ManagerLog("Quitting Game");
        }
        Application.Quit();
    }

}
