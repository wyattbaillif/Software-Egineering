using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MenuCleanUp : MonoBehaviour
{
    private void Awake()
    {
        if (NetworkManager.Singleton !=null){
            Destroy(NetworkManager.Singleton.gameObject);
        }

        if (SoftwareMultiplayer.Instance !=null){
            Destroy(SoftwareMultiplayer.Instance.gameObject);
        }

        if (SoftwareLobby.Instance !=null){
            Destroy(SoftwareLobby.Instance.gameObject);
        }
        
    }
}
