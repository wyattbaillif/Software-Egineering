using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class CharacterSelectPlayer : MonoBehaviour
{

    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject ReadyGameObject;
    [SerializeField] private PlayerVisual playerVisual;

    [SerializeField] private Button kickButton;
    [SerializeField] private TextMeshPro playerNameText;

    private void Awake(){
        kickButton.onClick.AddListener(()=>{
            PlayerData playerData = SoftwareMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            SoftwareLobby.Instance.KickPlayer(playerData.playerId.ToString());
            SoftwareMultiplayer.Instance.KickPlayer(playerData.clientId);
        });
    }
    private void Start(){
        SoftwareMultiplayer.Instance.OnPlayerDataNetworkListChanged += SoftwareMultiplayer_OnPlayerDataNetworkListChanged;
        PlayerReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;
        
        kickButton.gameObject.SetActive(NetworkManager.Singleton.IsServer);
        UpdatePlayer();
    }

    private void CharacterSelectReady_OnReadyChanged(object sender, EventArgs e)
    {
        UpdatePlayer();
    }

    private void SoftwareMultiplayer_OnPlayerDataNetworkListChanged(object sender, EventArgs e)
    {
        UpdatePlayer();
    }
    private void UpdatePlayer()
    {
        if (SoftwareMultiplayer.Instance.IsPlayerIndexConnected(playerIndex)){
            Show();

            PlayerData playerData = SoftwareMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);

            ReadyGameObject.SetActive(PlayerReady.Instance.IsPlayerReady(playerData.clientId));

            playerNameText.text=playerData.playerName.ToString();

            playerVisual.SetPlayerColor(SoftwareMultiplayer.Instance.GetPlayerColor(playerData.colorId));
        }
        else{
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy(){
        SoftwareMultiplayer.Instance.OnPlayerDataNetworkListChanged -= SoftwareMultiplayer_OnPlayerDataNetworkListChanged;
    }
}
