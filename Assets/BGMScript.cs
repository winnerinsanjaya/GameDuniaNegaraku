using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public static BGMScript BGMSInstance;
    private void Awake()
    {
        if (BGMSInstance == null)
        {
            BGMSInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
