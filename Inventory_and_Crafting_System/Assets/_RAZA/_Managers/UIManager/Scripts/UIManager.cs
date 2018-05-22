
using UnityEngine;
using UnityEngine.UI;

namespace ExtendedUnityEngine
{
    public class UIManager : MonoBehaviour
    {

        //Singleton Refference
        public static UIManager instance;

        public bool updateAllModulesOnStart;


        //UI Manager Health Variables
        [Header("Health Variables")]
        public float CurrentHealth;
        public float MaxHealth;
        public Image healthBar;
        public Text healthText;

        //UI Manager Stamina Variables
        [Header("Stamina Variables")]
        public float CurrentStamina;
        public float MaxStamina;
        public Image staminaBar;
        public Text staminaText;


        [Header("FPS Variables")]
        public int currentAmmo;
        public int clipSize, totalAmmo;
        public int currentGrenades, totalGrenades;
        public Text currentAmmoText, clipSizeText, totalAmmoText;
        public Text currentGrenadesText, totalGrenadesText;


        //Progression Variables
        [Header("Progression Variables")]
        public int EXP; public int Level;
        public int EXP_Required;
        public Image EXPBar;
        public Text EXPText;




        [Header("Enable/Disable UI Modules")]
        public bool useHealthModule;
        public bool useStaminaModule, useEXPModule, useFPSModule;

        [Header("Lerping Speeds")]
        public int HealthBarLerpSpeed = 1;
        public int StaminaBarLerpSpeed = 1;
        public int EXPBarLerpSpeed = 1;




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
            this.name = "[MANAGER]UIManager";

            //Check Tag
            if (!this.gameObject.CompareTag("Manager"))
            {
                XDebug.LogErrorRed(this.name + "'s Tag is not set to Manager", "!!!ERROR!!!");
            }
        }

        private void Start()
        {
            if (updateAllModulesOnStart)
            {
                UpdateHealthModule();
                UpdateFPSModule();
            }
        }


        private void FixedUpdate()
        {
            if (useHealthModule)
            {
                if (healthBar)
                {
                    healthBar.type = Image.Type.Filled;

                    float currentFillAmount = CurrentHealth / MaxHealth;

                    if (healthBar.fillAmount != currentFillAmount)
                    {
                        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentFillAmount, (HealthBarLerpSpeed * 2) * Time.deltaTime);
                    }
                }

            }
        }


        /// <summary>
        /// Updates the Health Related Variables and UI Elements
        /// </summary>
        public void UpdateHealthModule()
        {
            if (!useHealthModule)
            {
                XDebug.ManagerLog("HEALTH MODULE IS INACTIVE", "****UI MANAGER****");
                return;
            }


            if (healthText)
            {
                healthText.text = CurrentHealth.ToString();
            }

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }


        /// <summary>
        /// Updates the FPS Related Variables and UI Elements
        /// </summary>
        public void UpdateFPSModule()
        {
            if (!useFPSModule)
            {
                XDebug.ManagerLog("FPS MODULE IS INACTIVE", "****UI MANAGER****");
                return;
            }

            if (currentAmmoText)
            {
                currentAmmoText.text = currentAmmo.ToString();
            }

            if (clipSizeText)
            {
                clipSizeText.text = clipSize.ToString();
            }

            if (totalAmmoText)
            {
                totalAmmoText.text = totalAmmo.ToString();
            }

            if (currentGrenadesText)
            {
                currentGrenadesText.text = currentGrenades.ToString();
            }

            if (totalGrenadesText)
            {
                totalGrenadesText.text = totalGrenades.ToString();
            }

        }

    }
}
