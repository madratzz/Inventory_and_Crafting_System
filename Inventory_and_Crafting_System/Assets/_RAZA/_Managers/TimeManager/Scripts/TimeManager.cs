using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtendedUnityEngine
{
    public class TimeManager : MonoBehaviour
    {

        //Singleton Refference
        public static TimeManager instance;


        //Timer RelatedVariables

        //Default Timer for the TimeManager
        public Timer mainTimer;

        //List of Timers under Manager
        public List<Timer> timersList;



        void Awake()
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
            this.name = "[MANAGER]TimeManager";

            //Check Tag
            if (!this.gameObject.CompareTag("Manager"))
            {
                XDebug.LogErrorRed(this.name + "'s Tag is not set to Manager", "!!!ERROR!!!");
            }

            //Create Child Timer As MainTimer
            CreateTimerInstance("MainTimer", true);


            //Uncomment to see test case
            //TestMainTimer();
        }



        /// <summary>
        /// Creates A Timer under the TimeManager with default name "Timer"
        /// </summary>
        public void CreateTimerInstance()
        {
            GameObject Timer = new GameObject();
            Timer.transform.parent = this.transform;
            Timer.name = "Timer";
            Timer.AddComponent<Timer>();

            AddTimerInList(Timer.GetComponent<Timer>());

        }

        /// <summary>
        /// Creates A Timer under the TimeManager with the specified name
        /// </summary>
        /// <param name="name">The Name of the new Timer</param>
        public void CreateTimerInstance(string name)
        {
            GameObject Timer = new GameObject();
            Timer.transform.parent = this.transform;
            Timer.name = name;
            Timer.AddComponent<Timer>();

            AddTimerInList(Timer.GetComponent<Timer>());
        }


        /// <summary>
        /// Creates A Timer under the TimeManager with the specified name
        /// </summary>
        /// <param name="name">The Name of the new Timer</param>
        /// <param name="setAsMain">Should the new Timer be set as Default Timer or Not</param>
        public void CreateTimerInstance(string name, bool setAsMain)
        {
            GameObject Timer = new GameObject();
            Timer.transform.parent = this.transform;
            Timer.name = name;
            Timer.AddComponent<Timer>();

            AddTimerInList(Timer.GetComponent<Timer>());

            if (setAsMain)
            {
                //Set Manager's Main Timer
                mainTimer = Timer.GetComponent<Timer>();

                if (GetTimersCount() > 0)
                {
                    //Set the default timer to index 0
                    Swap<Timer>(timersList, 0, timersList.IndexOf(Timer.GetComponent<Timer>()));
                }
            }
        }

        /// <summary>
        /// Rerturns the number of timers currently working under TimeManager
        /// </summary>
        /// <returns>Number of timers in the TimeManger List</returns>
        public int GetTimersCount()
        {
            // Number of Timers under TimeManager
            return timersList.Count;
        }

        private void AddTimerInList(Timer timer)
        {
            //Add Timer to the list
            timersList.Add(timer);
        }


        /// <summary>
        /// Swaps the elements of a List at specified indexes
        /// </summary>
        /// <typeparam name="T">Type of the Object</typeparam>
        /// <param name="list">Source List</param>
        /// <param name="indexA">Index of First</param>
        /// <param name="indexB">Index of Second</param>
        private static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }



        #region TimerTest
        private void TestMainTimer()
        {
            mainTimer.TotalTime = 5f;
            mainTimer.Init();
            mainTimer.EnableDebugMode();
            mainTimer.timerMode = Timer.TimerMode.Incremental;

            //mainTimer.SetTimer(5f);

            if (mainTimer.TimerExpired == null)
            {
                XDebug.LogYellow("CallBackEmpty", "----");
                mainTimer.TimerExpired = new UnityEngine.Events.UnityEvent();
            }
            mainTimer.TimerExpired.AddListener(TestCallBack);

            CreateTimerInstance("XYZ");
            CreateTimerInstance("ABC", true);
        }

        private void TestCallBack()
        {
            XDebug.LogGreen("TIMER EXPIRE CALL BACK", "***");
            StartCoroutine(TestRestart());
        }

        IEnumerator TestRestart()
        {
            yield return new WaitForSeconds(2f);

            mainTimer.RestartTimer(10);


            if (mainTimer.TimerExpired == null)
            {
                XDebug.LogYellow("TimerCallBackEmpty", "----");
                mainTimer.TimerExpired = new UnityEngine.Events.UnityEvent();
            }
            mainTimer.TimerExpired.AddListener(TestCallBack);

            yield break;
        }

        #endregion

    }
}
