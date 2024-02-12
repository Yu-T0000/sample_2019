using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class Manager : MonoBehaviour
{
    public int feeling = 2;
    
    public string emote = "Neutral";

    public static Manager m_instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

       private void Awake()
    {
        m_instance = this;
        emote = "";
    }

     public void OnMessage(Message message) {
        if (message.address == "/feeling")
        {
            emote =(string)message.values[0];
        }
       
   }

    // Update is called once per frame
    void Update()
    {
        
        if (emote=="Good") {
            feeling = 3;
        }
        if (emote=="Neutral") {
            feeling = 2;
        }
        if (emote=="Bad") {
            feeling = 1;
        }
            
        }
    
    
}
