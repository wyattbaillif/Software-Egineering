using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using TMPro;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    [SerializeField] private Button LeaveButton;
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;

    private void Awake(){
        LeaveButton.onClick.AddListener(()=>{
            SoftwareLobby.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenu);
        });
    
        readyButton.onClick.AddListener(()=> {
            PlayerReady.Instance.SetPlayerReady();
        });
    }

    private void Start() {
        Lobby lobby = SoftwareLobby.Instance.GetLobby();

        lobbyNameText.text = "Lobby Name: " + lobby.Name;
        lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
    }
}
