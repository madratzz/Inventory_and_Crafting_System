//----------------------------------------------
// EXP MANAGER
// Copyright © RAZA BUTT
//----------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtendedUnityEngine;

public class EXPManager : MonoBehaviour
{

    //Singleton Refference
    public static EXPManager instance;

    public int MaxLevelCap;
    public int CurrentLevel;

    public int CurrentXP;
    public int LevelUpXP;

    public int baseXP;
    public float XPScaleFactor;



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
        this.name = "[MANAGER]EXP_MANAGER";

        //Check Tag
        if (!this.gameObject.CompareTag("Manager"))
        {
            XDebug.LogErrorRed(this.name + "'s Tag is not set to Manager", "!!!ERROR!!!");
        }
    }

    private void Start()
    {
        //Initialize the XP Manager on Start
        InitXPManager();
        //Modify the XP Scale Factor Also
        AdjustXPScaleFactor();
    }



    /// <summary>
    /// Initialize/Load the XP Manager
    /// </summary>
    public void InitXPManager()
    {
        //Check to See if we have not initialized the XP Manager
        if (PlayerPrefs.GetInt("isXPManagerInit", 0) == 0)
        {
            if (DebugManager.instance.isManagerDebugMode)
            {
                XDebug.ManagerLog("XP MANAGER NOT INITIALIZED, INITIALIZING");
            }
            //Save current XPManager Values
            SaveXPManager();
            PlayerPrefs.SetInt("isXPManagerInit", 1);

        }
        else
        {
            if (DebugManager.instance.isManagerDebugMode)
            {
                XDebug.ManagerLog("XP MANAGER INITIALIZED, LOADING VALUES");
            }

            MaxLevelCap = PlayerPrefs.GetInt("XPManager_MaxLevelCap");
            CurrentLevel = PlayerPrefs.GetInt("XPManager_CurrentLevel");
            CurrentXP = PlayerPrefs.GetInt("XPManager_CurrentXP");
            LevelUpXP = PlayerPrefs.GetInt("XPManager_LevelUpXP");
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Save the current State of the XP Manager
    /// </summary>
    public void SaveXPManager()
    {
        PlayerPrefs.SetInt("XPManager_MaxLevelCap", MaxLevelCap);
        PlayerPrefs.SetInt("XPManager_CurrentLevel", CurrentLevel);
        PlayerPrefs.SetInt("XPManager_CurrentXP", CurrentXP);
        PlayerPrefs.SetInt("XPManager_LevelUpXP", LevelUpXP);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Resets the XP Manager to Defaults
    /// </summary>
    public void ResetXPManager()
    {
        XDebug.ManagerLog("Resetting XP Manager, If the Reset is not as per requirement change the base code here", "**** RESETTING XP MANAGER ****");

        MaxLevelCap = 100;
        CurrentLevel = 1;
        CurrentXP = 0;
        LevelUpXP = 1000;

        SaveXPManager();
    }

    /// <summary>
    /// Add "Amount" to Current XP
    /// </summary>
    /// <param name="amount">The amount to be added to current XP</param>
    public void AddXP(int amount)
    {
        CurrentXP += amount;
        if (CurrentXP > LevelUpXP)
        {
            CurrentXP = CurrentXP - LevelUpXP;
            SetNextLevelUpXP();
            LevelUP();
        }
    }


    /// <summary>
    /// Set the Next XP Requirement
    /// </summary>
    private void SetNextLevelUpXP()
    {
        LevelUpXP = (int)(LevelUpXP + ((float)(baseXP / 2f) + (float)(baseXP * XPScaleFactor)));
    }

    /// <summary>
    /// Set the Current Player Level to Specified LevelNumber
    /// </summary>
    /// <param name="levelNumber">The LevelNumber to Set Player</param>
    public void SetLevel(int levelNumber)
    {
        CurrentLevel = levelNumber;
        CurrentXP = 0;
        if (levelNumber > MaxLevelCap)
        {
            XDebug.ManagerLog("Setting Level Above then Max Level Cap, Setting to MaxLevel", "***[MAX LEVEL CAP ERROR]***");
            CurrentLevel = MaxLevelCap;
        }
    }

    /// <summary>
    /// Levels Player Up by 1
    /// </summary>
    private void LevelUP()
    {
        CurrentLevel++;
        if (CurrentLevel > MaxLevelCap)
        {
            CurrentLevel = MaxLevelCap;
        }

        //Check and See if the Scale Factor Needs Re-Adjusting
        AdjustXPScaleFactor();
    }

    /// <summary>
    /// Modifies the Next Level XP Scale Factor According to Current Level
    /// </summary>
    private void AdjustXPScaleFactor()
    {

        if (CurrentLevel > 0)
        {
            XPScaleFactor = 0.25f;
        }
        if (CurrentLevel > 10)
        {
            XPScaleFactor = 0.35f;
        }

        if (CurrentLevel > 20)
        {
            XPScaleFactor = 0.45f;
        }
    }
}
