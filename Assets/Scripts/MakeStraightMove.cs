using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStraightMove : MonoBehaviour
{
    public PlayerController player;
    


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        player.manekinMove =new Vector2(0f,0.67f);
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        player.manekinMove =new Vector2(0f,0.67f);
        
    }
}
