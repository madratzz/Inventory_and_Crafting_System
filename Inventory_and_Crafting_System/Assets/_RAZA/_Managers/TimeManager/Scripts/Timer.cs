
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ExtendedUnityEngine
{
    public class Timer : MonoBehaviour
    {
        public enum TimerMode { Incremental, Decremental };
        public float TotalTime = 0f;
        public TimerMode timerMode;



        private float timer = 0f;
        private string minutes, seconds;

        private bool isExpired = false;

        public Text timerClock;

        [SerializeField]
        private bool isDebug;


        [SerializeField]
        public UnityEvent TimerExpired;


        //private void Start()
        //{
        //    //TotalTime = (PlayerPrefs.GetInt("SP_Time") * 60);
        //    //Init();
        //}

        public void Init()
        {
            if (timerMode == TimerMode.Incremental)
            {
                SetTimer(0);
                InvokeRepeating("IncrementTime", 0f, 1f);
            }
            else
            {
                SetTimer(TotalTime);
                InvokeRepeating("DecrementTime", 0f, 1f);
            }
        }

        private void FormatTime(float time)
        {
            minutes = Mathf.Floor(timer / 60).ToString("00");
            seconds = (timer % 60).ToString("00");

            if (timerClock)
            {
                timerClock.text = minutes + ":" + seconds;
            }

            if (isDebug)
            {
                Debug.Log(minutes + ":" + seconds);
            }
        }

        private void DecrementTime()
        {
            if (isExpired)
            {
                Debug.Log("Game Timer is Expired");
                return;
            }
            if (timer > 0)
            {
                timer--;
            }
            else if (timer == 0)
            {
                if (TimerExpired != null)
                {
                    TimerExpired.Invoke();
                }
                isExpired = true;
                CancelInvoke("IncrementTime");
                CancelInvoke("DecrementTime");
                if (isDebug)
                {
                    Debug.Log("TimerExpired");
                }
            }

            if (!isExpired)
                FormatTime(timer);
        }

        private void IncrementTime()
        {
            if (isExpired)
            {
                Debug.Log("Game Timer is Expired");
                return;
            }
            if (timer < TotalTime)
            {
                timer++;
            }
            else if (timer == TotalTime)
            {
                if (isDebug)
                {
                    XDebug.ManagerLog("Invoking Expired Event", "****TIMER****");
                    TimerExpired.Invoke();
                }
                else
                {
                    TimerExpired.Invoke();
                }

                isExpired = true;
                CancelInvoke("IncrementTime");
                CancelInvoke("DecrementTime");
                if (isDebug)
                {
                    XDebug.ManagerLog("TimerExpired", "****TIMER****");
                }
            }

            if (!isExpired)
                FormatTime(timer);
        }


        public void SetTimer(float time)
        {
            if (isDebug)
            {
                Debug.Log("Setting Timer: " + time);
            }

            timer = time;
            //startTime = time;
        }

        public void ResetTimer()
        {
            isExpired = false;
            Init();
        }

        public void RestartTimer(float time)
        {
            TotalTime = time;
            SetTimer(time);
            ResetTimer();

        }

        public void EnableDebugMode()
        {
            isDebug = true;
        }

        public void DisableDebugMode()
        {
            isDebug = false;
        }
    }
}

