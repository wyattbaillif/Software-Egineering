using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodyColor;

    private Material material;

    private void Awake(){
        material = new Material(bodyColor.material);
        bodyColor.material = material;
    }

    

    public void SetPlayerColor(Color color){
        material.color = color;
    }
}
