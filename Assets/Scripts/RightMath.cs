using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMath : MonoBehaviour
{  bool startTimer;
    float timeToDestroy = 1f;
    PlayerController player;
    [Tooltip("This slider sets mathematical operation for object : 1 - plus | 2 - minus | 3 - multiply | 4 - devide  ")]
    [Range(1,4)]
    [SerializeField]int math;
    [SerializeField]int amount;
    [SerializeField]private Text text;

    

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
         switch (math)
            {
                case 1: 
                    text.text = "+ " + amount.ToString();
                    break;
                case 2:
                    text.text = "- " + amount.ToString();
                    break;
                case 3:
                    text.text = "* " + amount.ToString();
                    break;
                case 4:
                    text.text = "÷ " + amount.ToString();
                    break;

                default:
                break;
            }
    }
    private void Update() {
        
        if(startTimer)
        {
            timeToDestroy -= Time.deltaTime;
        }
        if(timeToDestroy<=0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            startTimer = true;
            //player.AddPlayers(5);
           // player.MultiplyPlayers(3);

            switch (math)
            {
                case 1: 
                    player.AddPlayers(amount);
                    Debug.LogWarning("ADD");
                    break;
                case 2:
                    player.RemovePlayers(amount);
                    Debug.LogWarning("Remove");
                    break;
                case 3:
                    player.MultiplyPlayers(amount);
                    Debug.LogWarning("Multiply");
                    break;
                case 4:
                    player.DevidePlayers(amount);
                    Debug.LogWarning("Devide");
                    break;

                default:
                break;
            }
            GetComponent<BoxCollider>().enabled =false;
        }
    }
}
