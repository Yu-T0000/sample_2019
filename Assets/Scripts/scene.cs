using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using uOSC;

public class scene : MonoBehaviour
{
    uOscClient client;
    // Start is called before the first frame update
    void Awake()
    {
        client = GetComponent<uOscClient>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            client.Send("/motorB", "hld",00);
            this.GetComponent<Controller_Brain>().pause();
            SceneManager.LoadScene("pause");
        }
        
    }
}
