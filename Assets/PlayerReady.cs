using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using System;

public class PlayerReady : NetworkBehaviour
{
    public static PlayerReady Instance {get; private set;}

    public event EventHandler OnReadyChanged;
    private Dictionary<ulong, bool> playerReadyDictionary;

    private void Awake()
    {
        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }


    public void SetPlayerReady(){
        SetPlayerReadyServerRpc();
    }
    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default){
        setPlayerReadyClientRpc(serverRpcParams.Receive.SenderClientId);
        playerReadyDictionary[serverRpcParams.Receive.SenderClientId]=true;

        bool allClientsReady = true;
        int numClients=0;
        foreach (ulong clientID in NetworkManager.Singleton.ConnectedClientsIds){
            numClients+=1;
            if (!playerReadyDictionary.ContainsKey(clientID) || !playerReadyDictionary[clientID]){
                allClientsReady=false;
                break;
            }
        }

        if (allClientsReady && (numClients>1)){
            SoftwareLobby.Instance.DeleteLobby();
            Loader.LoadNetwork(Loader.Scene.Game);
        }
    }
    [ClientRpc]
    private void setPlayerReadyClientRpc(ulong clientId){
        playerReadyDictionary[clientId] = true;

        OnReadyChanged?.Invoke(this,EventArgs.Empty);
    }

    public bool IsPlayerReady(ulong clientId){
        return playerReadyDictionary.ContainsKey(clientId) && playerReadyDictionary[clientId];
    }
}
