using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using Cysharp.Threading.Tasks;
using uOSC;

public class Controller_Brain : MonoBehaviour
{
    uOscClient send_to_python;

    uOscClient client;

    public GameObject Client_phone;
    public GameObject Client_lego;
    public int state = 0;
     public void Awake()
    {
        Client_phone = GameObject.Find ("Client_phone");
        Client_lego = GameObject.Find ("Client_lego");
        send_to_python = Client_lego.GetComponent<uOSC.uOscClient>();
        client = Client_phone.GetComponent<uOscClient>();

    }
    public void OnMessage(Message message){
        if (message.address == "/damage_con")
        {
            Debug.Log("received");
        }
    }
    public async void Confuse(){
        state = 0;
        Debug.Log("Confuse()");
        send_to_python.Send("/motorA", "fwd",40);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        send_to_python.Send("/motorB", "rev",30);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        send_to_python.Send("/motorA", "fwd",40);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        send_to_python.Send("/motorA", "rev",30);
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        client.Send("/damage2");
        Debug.Log("send/damage2");
        send_to_python.Send("/motorB", "stp",0);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        send_to_python.Send("/motorA", "stp",0);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        client.Send("/damage2");
        Debug.Log("Confuse():end");
        send_to_python.Send("/motorAll", "stp",0);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        send_to_python.Send("/motorAll", "stp",0);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        client.Send("/damage2");
    }

    public void pause(){
        client.Send("/pause");
    }
    void Update(){
    }

}