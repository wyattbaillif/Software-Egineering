using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Services.Lobbies.Models;
using System;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button CreateGameButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button QuickJoinButton;
    [SerializeField] private Button JoinCodeButton;
    [SerializeField] private LobbyCreateUI lobbyCreateUI;
    [SerializeField] private TMP_InputField joinCodeInputfeild;
    [SerializeField] private TMP_InputField playerNameInputFeild;
    [SerializeField] private Transform lobbyContainer;
    [SerializeField] private Transform lobbyTemplate;


    private void Awake() {

        MainMenuButton.onClick.AddListener(()=> {
            SoftwareLobby.Instance.LeaveLobby();
            Loader.Load(Loader.Scene.MainMenu);
        });

        CreateGameButton.onClick.AddListener(()=> {
            lobbyCreateUI.Show();
        });

        QuickJoinButton.onClick.AddListener(()=> {
            SoftwareLobby.Instance.QuickJoin();
        });
        JoinCodeButton.onClick.AddListener(()=> {
            SoftwareLobby.Instance.JoinWithCode(joinCodeInputfeild.text);
        });

        lobbyTemplate.gameObject.SetActive(false);

    }

    private void Start(){
        playerNameInputFeild.text=SoftwareMultiplayer.Instance.GetPlayerName();
        playerNameInputFeild.onValueChanged.AddListener((string newText)=>{
            SoftwareMultiplayer.Instance.SetPlayerName(newText);
        });

        SoftwareLobby.Instance.OnLobbyListchanged += SoftwareLobby_OnLobbyListchanged;
        UpdateLobbyList(new List<Lobby>());
    }

    private void SoftwareLobby_OnLobbyListchanged(object sender, SoftwareLobby.OnLobbyListchangedEventArgs e)
    {
        UpdateLobbyList(e.lobbyList);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList){
        foreach(Transform child in lobbyContainer){
            if(child == lobbyTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(Lobby lobby in lobbyList){
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }

    private void OnDestroy(){
        SoftwareLobby.Instance.OnLobbyListchanged -= SoftwareLobby_OnLobbyListchanged;
    }
}
