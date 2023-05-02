using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake(){
        closeButton.onClick.AddListener(Hide);
    }

    private void Start(){
        SoftwareMultiplayer.Instance.OnFailedToJoinGame += SoftwareMultiplayer_OnFailedToJoinGame;
        SoftwareLobby.Instance.OnCreateLobbyStarted += SoftwareLobby_OnCreateLobbyStarted;
        SoftwareLobby.Instance.OnCreateLobbyFailed += SoftwareLobby_OnCreateLobbyFailed;
        SoftwareLobby.Instance.OnJoinStarted += SoftwareLobby_OnJoinStarted;
        SoftwareLobby.Instance.OnJoinFailed += SoftwareLobby_OnJoinFailed;
        SoftwareLobby.Instance.OnQuickJoinFailed += SoftwareLobby_OnQuickJoinFailed;

        Hide();
    }

    private void SoftwareLobby_OnQuickJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Could not find a Lobby to Quick Join");
    }

    private void SoftwareLobby_OnJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Connection Failed");
    }

    private void SoftwareLobby_OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining Lobby...");
    }

    private void SoftwareLobby_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Lobby Creation Failed");
    }

    private void SoftwareLobby_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating Lobby");
    }

    private void SoftwareMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        ShowMessage("Connection Failed");
    }

    private void ShowMessage(string message){
        Show();
        messageText.text = message;
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        SoftwareMultiplayer.Instance.OnFailedToJoinGame -= SoftwareMultiplayer_OnFailedToJoinGame;
        SoftwareLobby.Instance.OnCreateLobbyStarted -= SoftwareLobby_OnCreateLobbyStarted;
        SoftwareLobby.Instance.OnCreateLobbyFailed -= SoftwareLobby_OnCreateLobbyFailed;
        SoftwareLobby.Instance.OnJoinStarted -= SoftwareLobby_OnJoinStarted;
        SoftwareLobby.Instance.OnJoinFailed -= SoftwareLobby_OnJoinFailed;
        SoftwareLobby.Instance.OnQuickJoinFailed -= SoftwareLobby_OnQuickJoinFailed;
    }
}
