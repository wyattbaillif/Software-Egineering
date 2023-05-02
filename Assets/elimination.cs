using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class elimination : NetworkBehaviour
{
    public bool playerDead = false;

    public string User;

    public float Time;

    public int Id;

    public Vector3 lockPos = new Vector3(0f,0f,0f);
    
    public static elimination Instance {get; private set;}

    private void Awake(){
        Instance = this;
    }
    void Start(){
        PlayerData playerData = SoftwareMultiplayer.Instance.GetPlayerData();
        User = playerData.playerName.ToString();
        Id=int.Parse(playerData.clientId.ToString());
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag.Equals("Projectile")) {
            gameObject.GetComponent<Transform>().position = lockPos;
            gameObject.GetComponent<MovementTest>().enabled=false;
            gameObject.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
            Destroy(coll.gameObject);
            playerDead = true;
            Time=GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime;
        }
    }


}
