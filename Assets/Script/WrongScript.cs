using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongScript : MonoBehaviour
{


    [SerializeField] private float count;
    
    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if (count > 0)
        {
            return;
        }
        Destroy(gameObject);
    }
}
