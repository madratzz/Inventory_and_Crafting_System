//----------------------------------------------
// Debug MANAGER
// Copyright © RAZA BUTT
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtendedUnityEngine;

public class DebugManager : MonoBehaviour
{
    //Singleton Refference
    public static DebugManager instance;

    public bool isManagerDebugMode, isGamePlayDebugMode, isUIDebugMode, isAdsDebugMode;


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

        //ForceName
        this.name = "[MANAGER]DEBUG_MANAGER";

        //Check Tag
        if (!this.gameObject.CompareTag("Manager"))
        {
            XDebug.LogErrorRed(this.name + "'s Tag is not set to Manager", "!!!ERROR!!!");
        }
    }
}
