using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtendedUnityEngine;

public class TransformDemo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        XDebug.LogGreen("First Child with Matching Tag: " + this.transform.FindFirstChildWithTag("Player").name);
        XDebug.LogGreen("Last Child with Matching Tag: " + this.transform.FindLastChildWithTag("Player").name);


        GameObject[] childrenFound = this.transform.FindAllChildrenWithTag("Player");

        XDebug.LogBlue("Children Found: " + childrenFound.Length, "****");
        for (int i = 0; i < childrenFound.Length; i++)
        {
            XDebug.LogGreen(childrenFound[i].name);
        }
    }
}
