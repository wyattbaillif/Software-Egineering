using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System;

public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;



    private void Awake(){
        playAgainButton.onClick.AddListener(()=>{
            Loader.Load(Loader.Scene.MainMenu);
        });
    }

    private void Start() {
        NetworkManager.Singleton.OnClientDisconnectCallback+= NeworkManager_OnClientDisconnectCallback;

        Hide();
    }

    private void NeworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        if (clientId==NetworkManager.ServerClientId){
            Show();
        }
    }

    private void Show(){
        gameObject.SetActive(true);
    }

    private void Hide(){
        gameObject.SetActive(false);
    }

    private void OnDestroy(){
        NetworkManager.Singleton.OnClientDisconnectCallback-= NeworkManager_OnClientDisconnectCallback;
    }
}
