using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class DontDestroyScript : MonoBehaviour
{
    [SerializeField]
    public string[] DestroyInScenes;

    public static DontDestroyScript instance;

    //public bool checkForDuplicates;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if (checkForDuplicates)
        //{
        //    DontDestroyScript[] dontDestroyScripts = GameObject.FindObjectsOfType<DontDestroyScript>();
        //    for (int i = 0; i < dontDestroyScripts.Length; i++)
        //    {
        //        for (int j = 0; j < dontDestroyScripts.Length; j++)
        //        {
        //            if (i != j)
        //            {
        //                if (dontDestroyScripts[i] != null && dontDestroyScripts[j] != null)
        //                {
        //                    if (dontDestroyScripts[i].gameObject.name.Equals(dontDestroyScripts[j].gameObject.name))
        //                    {
        //                        Destroy(dontDestroyScripts[j].gameObject);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        foreach (string gameScene in DestroyInScenes)
        {
            if (gameScene.Equals(scene.name))
            {
                Debug.Log("OnSceneLoaded: " + scene.name);
                Debug.Log(mode);
                DestorGameObject();
            }
        }

    }

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
        DontDestroyOnLoad(gameObject);
        #endregion


    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    //private void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    public void DestorGameObject()
    {
        Destroy(this.gameObject);
    }

}
