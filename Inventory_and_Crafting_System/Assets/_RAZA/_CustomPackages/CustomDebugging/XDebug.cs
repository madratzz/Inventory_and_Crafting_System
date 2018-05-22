using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtendedUnityEngine
{
    public static class XDebug
    {
        #region COLORED LOGS

        /// <summary>
        /// Logs the message to UnityConsole in Red Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void LogRed(string log)
        {
            Debug.Log("<color=red>" + log + "</color>");
        }

        /// <summary>
        /// Logs the message to UnityConsole in Red Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void LogRed(string log, string extender)
        {
            Debug.Log("<color=red>" + extender + log + extender + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Blue Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void LogBlue(string log)
        {
            Debug.Log("<color=blue>" + log + "</color>");
        }

        /// <summary>
        /// Logs the message to UnityConsole in Blue Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void LogBlue(string log, string extender)
        {
            Debug.Log("<color=blue>" + extender + log + extender + "</color>");
        }

        /// <summary>
        /// Logs the message to UnityConsole in Yellow Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void LogYellow(string log)
        {
            Debug.Log("<color=yellow>" + log + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Yellow Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void LogYellow(string log, string extender)
        {
            Debug.Log("<color=yellow>" + extender + log + extender + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Green Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void LogGreen(string log)
        {
            Debug.Log("<color=green>" + log + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Green Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void LogGreen(string log, string extender)
        {
            Debug.Log("<color=green>" + extender + log + extender + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Purple Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void ManagerLog(string log)
        {
            Debug.Log("<color=purple>" + log + "</color>");
        }


        /// <summary>
        /// Logs the message to UnityConsole in Purple Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void ManagerLog(string log, string extender)
        {
            Debug.Log("<color=purple>" + extender + log + extender + "</color>");
        }


        /// <summary>
        /// Logs the message to Unity Error Console in Red Color
        /// </summary>
        /// <param name="log">String Message to Display</param>
        public static void LogErrorRed(string log)
        {
            Debug.LogError("<color=red>" + log + "</color>");
        }

        /// <summary>
        /// Logs the message to Unity Error Console in Red Color with Custom Extender
        /// </summary>
        /// <param name="log">String Message to Display</param>
        /// <param name="extender">The custom string before and after the log message</param>
        public static void LogErrorRed(string log, string extender)
        {
            Debug.LogError("<color=red>" + extender + log + extender + "</color>");
        }

        #endregion COLORED LOGS
    }
}
