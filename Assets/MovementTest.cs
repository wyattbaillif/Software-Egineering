using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class MovementTest : NetworkBehaviour
{

    [SerializeField] private List<Vector3> SpawnPosList;
    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private Transform projectile;

    public float speed =.05f;

    public override void OnNetworkSpawn()
    {
        transform.position=SpawnPosList[SoftwareMultiplayer.Instance.GetPlayerDataIndexFromClietnId(OwnerClientId)];
    }

    private void Start(){
        PlayerData playerData = SoftwareMultiplayer.Instance.GetPlayerDataFromClietnId(OwnerClientId);
        playerVisual.SetPlayerColor(SoftwareMultiplayer.Instance.GetPlayerColor(playerData.colorId));
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {


        if(IsOwner)
        {
            float xDirection = Input.GetAxis("Horizontal");
            float yDirection = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.0f);

            transform.position += moveDirection * speed;
        }
        

    }
}
