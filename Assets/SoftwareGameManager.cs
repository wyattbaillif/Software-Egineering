using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;

public class SoftwareGameManager : NetworkBehaviour
{
    public static SoftwareGameManager Instance {get; private set;}
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform bossPrefab;



    private void Awake(){
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        if(IsServer){
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
        }
    }

    private void SceneManager_OnLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds){
            Transform playerTransform = Instantiate(playerPrefab);
            playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
        }
        Transform BossTransform = Instantiate(bossPrefab);
        BossTransform.GetComponent<NetworkObject>().Spawn(true);
        
    }
}