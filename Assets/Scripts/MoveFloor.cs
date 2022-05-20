using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
   
   private void OnTriggerEnter(Collider other) {
       
       if(other.tag == "Player")
       {
           transform.position += -transform.right*25;
       }
   }
}
