using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public Transform hitter;
    // Update is called once per frame
    void Update()
    {
       /*  RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(hitter.position,hitter.position + new Vector3(10f,0f,0f), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(hitter.position,hitter.position + new Vector3(10f,0f,0f) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

        }*/

        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Debug.Log("Trigger");
        }
    }
}
