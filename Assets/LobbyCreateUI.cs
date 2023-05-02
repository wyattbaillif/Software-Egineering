using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button createPublicButton;
    [SerializeField] private Button createPrivateButton;
    [SerializeField] private TMP_InputField lobbyNameInputFeild;


    private void Awake(){
        createPublicButton.onClick.AddListener(()=> {
            SoftwareLobby.Instance.CreateLobby(lobbyNameInputFeild.text,false);
        });
        createPrivateButton.onClick.AddListener(()=> {
            SoftwareLobby.Instance.CreateLobby(lobbyNameInputFeild.text,true);
        });
        closeButton.onClick.AddListener(()=>{
            Hide();
        });
    }

    private void Start(){
        Hide();
    }

    private void Hide(){
        gameObject.SetActive(false);
    }
    public void Show(){
        gameObject.SetActive(true);
    }
}
