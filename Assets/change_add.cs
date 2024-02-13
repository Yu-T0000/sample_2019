using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class change_add : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        string ipAddress = PlayerPrefs.GetString("IP");
        GetComponent<uOscClient>().address = ipAddress;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
