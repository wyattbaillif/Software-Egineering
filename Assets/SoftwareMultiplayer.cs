using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;
using Unity.Services.Authentication;

public class SoftwareMultiplayer : NetworkBehaviour
{

    [SerializeField] private List<Color> playerColorList;
    private NetworkList<PlayerData> playerDataNetworkList;
    private const int MAX_PLAYERS = 4;
    private const string PLAYER_PREFS_PLAYER_NAME_MULTIPLAYER="PlayerNameMultiplayer";
    public static SoftwareMultiplayer Instance {get; private set;}

    public event EventHandler OnTryingToJoinGame;
    public event EventHandler OnFailedToJoinGame;

    public event EventHandler OnPlayerDataNetworkListChanged;

    private string playerName;


    public bool IsPlayerIndexConnected(int playerIndex){
        return playerIndex < playerDataNetworkList.Count;
    }
    private void Awake(){
        Instance = this;

        DontDestroyOnLoad(gameObject);

        playerName=PlayerPrefs.GetString(PLAYER_PREFS_PLAYER_NAME_MULTIPLAYER, "PlayerName" + UnityEngine.Random.Range(100,1000));
        playerDataNetworkList = new NetworkList<PlayerData>();
        playerDataNetworkList.OnListChanged += PlayerDataNetworkList_OnListChanged;
    }

    public string GetPlayerName(){
        return playerName;
    }

    public void SetPlayerName(string playerName){
        this.playerName=playerName;

        PlayerPrefs.SetString(PLAYER_PREFS_PLAYER_NAME_MULTIPLAYER, playerName);
    }

    private void PlayerDataNetworkList_OnListChanged(NetworkListEvent<PlayerData> changeEvent)
    {
        OnPlayerDataNetworkListChanged?.Invoke(this,EventArgs.Empty);
    }

    public void StartHost(){
        NetworkManager.Singleton.ConnectionApprovalCallback += NetworkManager_ConnectionApprovalCallback;
        NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_Server_OnClientDisconnectCallback;
        NetworkManager.Singleton.StartHost();
    }

    private void NetworkManager_Server_OnClientDisconnectCallback(ulong clientId)
    {
        for (int i = 0; i < playerDataNetworkList.Count; i++){
            PlayerData playerData = playerDataNetworkList[i];
            if (playerData.clientId==clientId){
                //Disconnected ID
                playerDataNetworkList.RemoveAt(i);
            } 
        }
    }

    private void NetworkManager_OnClientConnectedCallback(ulong clientId)
    {
        playerDataNetworkList.Add(new PlayerData {
            clientId = clientId,
            colorId = NetworkManager.ConnectedClientsIds.Count-1,
        });
        SetPlayerNameServerRpc(GetPlayerName());
        SetPlayerIdServerRpc(AuthenticationService.Instance.PlayerId);
    }

    private void NetworkManager_ConnectionApprovalCallback(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
    {
        if(SceneManager.GetActiveScene().name != Loader.Scene.WaitingScene.ToString())
        {
            connectionApprovalResponse.Approved = false;
            return;
        }
        if (NetworkManager.Singleton.ConnectedClientsIds.Count >= MAX_PLAYERS)
        {
            connectionApprovalResponse.Approved = false;
            return;
        }

        connectionApprovalResponse.Approved = true;
        connectionApprovalResponse.CreatePlayerObject=true;
    }

    public void StartClient(){
        OnTryingToJoinGame?.Invoke(this,EventArgs.Empty);

        NetworkManager.Singleton.OnClientDisconnectCallback +=NetworkManager_Client_OnClientDisconnectCallback;
        NetworkManager.Singleton.OnClientConnectedCallback +=NetworkManager_Client_OnClientConnectedCallback;
        NetworkManager.Singleton.StartClient();
    }

    private void NetworkManager_Client_OnClientConnectedCallback(ulong clientId)
    {
        SetPlayerNameServerRpc(GetPlayerName());
        SetPlayerIdServerRpc(AuthenticationService.Instance.PlayerId);
    }

    [ServerRpc(RequireOwnership=false)]
    private void SetPlayerNameServerRpc(string playerName, ServerRpcParams serverRpcParams = default){
        int playerDataIndex = GetPlayerDataIndexFromClietnId(serverRpcParams.Receive.SenderClientId);
        PlayerData playerData = playerDataNetworkList[playerDataIndex];
        playerData.playerName=playerName;
        playerDataNetworkList[playerDataIndex]=playerData;
    }

    [ServerRpc(RequireOwnership=false)]
    private void SetPlayerIdServerRpc(string playerId, ServerRpcParams serverRpcParams = default){
        int playerDataIndex = GetPlayerDataIndexFromClietnId(serverRpcParams.Receive.SenderClientId);
        PlayerData playerData = playerDataNetworkList[playerDataIndex];
        playerData.playerId=playerId;
        playerDataNetworkList[playerDataIndex]=playerData;
    }
    private void NetworkManager_Client_OnClientDisconnectCallback(ulong clientId)
    {
        OnFailedToJoinGame?.Invoke(this, EventArgs.Empty);
    }

    public PlayerData GetPlayerDataFromPlayerIndex(int playerIndex){
        return playerDataNetworkList[playerIndex];
    }

    public Color GetPlayerColor(int colorId){
        return playerColorList[colorId];
    }

    [ServerRpc(RequireOwnership = false)]
    private void ChangePlayerColorServerRpc(int colorId, ServerRpcParams serverRpcParams = default){
        int playerDataIndex = GetPlayerDataIndexFromClietnId(serverRpcParams.Receive.SenderClientId);
        PlayerData playerData = playerDataNetworkList[playerDataIndex];
        playerData.colorId=colorId;
        playerDataNetworkList[playerDataIndex]=playerData;
    }
    public void ChangePlayerColor(int colorId){
        ChangePlayerColorServerRpc(colorId);
    }

    public int GetPlayerDataIndexFromClietnId(ulong clientId){
        for (int i=0; i<playerDataNetworkList.Count; i++){
            if (playerDataNetworkList[i].clientId == clientId){
                return i;
            }
        }
        return -1;
    }

    public PlayerData GetPlayerDataFromClietnId(ulong clientId){
        foreach (PlayerData playerData in playerDataNetworkList){
            if (playerData.clientId == clientId){
                return playerData;
            }
        }
        return default;
    }
    public PlayerData GetPlayerData(){
        return GetPlayerDataFromClietnId(NetworkManager.Singleton.LocalClientId);
    }

    public void KickPlayer(ulong clientId){
        NetworkManager.Singleton.DisconnectClient(clientId);
        NetworkManager_Server_OnClientDisconnectCallback(clientId);
    }

}
