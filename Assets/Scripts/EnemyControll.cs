using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    Transform lookAt;
    [SerializeField]bool isFacingTarget;
    public Transform hitter;
    RaycastHit hit;

    PlayerController player;
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
        if(lookAt !=null){
            transform.LookAt(lookAt.position);
            player = lookAt.GetComponentInParent<PlayerController>();
        }
               Debug.Log(lookAt);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {

            MakeRay();
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        {
            MakeRay();
        }
    }
    private void OnTriggerExit(Collider other) {
        player = null;
    }
    void MakeRay(){
       
       if(!isFacingTarget)      
       {
           Debug.DrawLine(hitter.position,hit.point,Color.yellow,0.2f);
            for (int i = 0; i < 8; i++)
            {
            
            
                
                
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(hitter.position,hitter.localPosition + new Vector3(10f,0f,2f*i), out hit, Mathf.Infinity,~0))
                {
                    //Debug.DrawRay(hitter.position,hitter.localPosition + new Vector3(1f,0f,2f*i) * hit.distance, Color.red);
                    Debug.DrawLine(hitter.position,hit.point,Color.yellow,0.2f);
                    if(hit.transform.tag =="Player")
                    {

                        lookAt = hit.transform;
                        isFacingTarget = true;
                        return;

                    }
                    

                }
                if (Physics.Raycast(hitter.position,hitter.localPosition + new Vector3(10f,0f,-2f*i), out hit, Mathf.Infinity,~0))
                {
                    
                    //Debug.DrawRay(hitter.position,hitter.localPosition + new Vector3(10f,0f,-2f*i) * hit.distance, Color.red);
                    Debug.DrawLine(hitter.position,hit.point,Color.yellow,0.2f);
                    if(hit.transform.tag =="Player")
                    {
                        lookAt = hit.transform;
                        isFacingTarget = true;
                        return;
                    }

                }
            }
       }

       if(isFacingTarget)
       {
           float distance = Vector3.Distance(transform.position,lookAt.position);
           if(distance>10f)
           {
               lookAt =null;
               isFacingTarget = false;
           }
       }
    }
    public void Example(){
        if(player != null)
        {
            player.RemovePlayers(1);

        }
    }
}
