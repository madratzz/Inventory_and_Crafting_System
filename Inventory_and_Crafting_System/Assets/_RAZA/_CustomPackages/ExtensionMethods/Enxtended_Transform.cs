using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtendedUnityEngine
{
    public static class Enxtended_Transform
    {
        /// <summary>
        /// Iterate over all the children to find the 1st GameObject with tag
        /// </summary>
        /// <param name="m_transform">Transform Target</param>
        /// <param name="tag">String Tag to Match</param>
        /// <returns>Returns the 1st Child with desired Tag, Or returns null if the Target Transfomr has no child</returns>
        public static GameObject FindFirstChildWithTag(this Transform target, string tag)
        {
            GameObject childGameObject = null;

            if (target.childCount == 0)
            {
                XDebug.LogRed("Transform has no Children, RETURNING NULL", "**[EXTENSION METHOD ERROR]**");
                return childGameObject;
            }
            else
            {
                //Iterate over all the children to find the 1st GameObject with tag
                for (int i = 1; i < target.childCount; i++)
                {
                    if (target.GetChild(i).gameObject.CompareTag(tag))
                    {
                        childGameObject = target.GetChild(i).gameObject;
                        break;
                    }
                }
            }

            return childGameObject;
        }




        /// <summary>
        /// Iterate over all the children to find the Last GameObject with tag
        /// </summary>
        /// <param name="m_transform">Transform Target</param>
        /// <param name="tag">String Tag to Match</param>
        /// <returns>Returns the Last Child with desired Tag, Or returns null if the Target Transfomr has no child</returns>
        public static GameObject FindLastChildWithTag(this Transform target, string tag)
        {
            GameObject childGameObject = null;

            if (target.childCount == 0)
            {
                XDebug.LogRed("Transform has no Children, RETURNING NULL", "**[EXTENSION METHOD ERROR]**");
                return childGameObject;
            }
            else
            {
                //Iterate over all the children to find the Last GameObject with tag
                for (int i = 1; i < target.childCount; i++)
                {
                    if (target.GetChild(i).gameObject.CompareTag(tag))
                    {
                        childGameObject = target.GetChild(i).gameObject;
                    }
                }
            }

            return childGameObject;
        }

        /// <summary>
        /// Iterate over all the children to find the All GameObjects with tag
        /// </summary>
        /// <param name="m_transform">Transform Target</param>
        /// <param name="tag">String Tag to Match</param>
        /// <returns>Returns the All Children with desired Tag, Or returns null if the Target Transfomr has no child</returns>
        public static GameObject[] FindAllChildrenWithTag(this Transform target, string tag)
        {
            GameObject[] childGameObject = null;
            int count = 0;

            if (target.childCount == 0)
            {
                XDebug.LogRed("Transform has no Children, RETURNING NULL", "**[EXTENSION METHOD ERROR]**");
                return childGameObject;
            }
            else
            {
                //Iterate over all the children to find the All GameObjects with tag
                for (int i = 1; i < target.childCount; i++)
                {
                    if (target.GetChild(i).gameObject.CompareTag(tag))
                    {
                        count++;
                    }
                }

                childGameObject = new GameObject[count];
                count = 0; //Re-Initialize to be the counter of the New Array

                for (int i = 1; i < target.childCount; i++)
                {
                    if (target.GetChild(i).gameObject.CompareTag(tag))
                    {
                        childGameObject[count] = target.GetChild(i).gameObject;
                        count++;
                    }
                }
            }

            return childGameObject;
        }

    }
}
