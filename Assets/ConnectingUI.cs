using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{

    private void Start(){
        SoftwareMultiplayer.Instance.OnTryingToJoinGame += SoftwareMultiplayer_OnTryingToJoinGame;
        SoftwareMultiplayer.Instance.OnTryingToJoinGame += SoftwareGameManager_OnFailedToJoinGame;
        Hide();
    }

    private void SoftwareGameManager_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Show();
    }

    private void SoftwareMultiplayer_OnTryingToJoinGame(object sender, EventArgs e)
    {
        Hide();
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
    private void OnDestroy() {
        SoftwareMultiplayer.Instance.OnTryingToJoinGame -= SoftwareMultiplayer_OnTryingToJoinGame;
        SoftwareMultiplayer.Instance.OnTryingToJoinGame -= SoftwareGameManager_OnFailedToJoinGame;
    }
}
