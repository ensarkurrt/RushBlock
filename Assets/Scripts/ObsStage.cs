using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//90 distance

public class ObsStage : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject player;
    GameManager gameManager;
    public GameObject prefabsObsStage;
    public float distance;

    public int numberOne=0,numberTwo=0;

    bool canBeDuo = false;
    void Start(){
        distance = FindObjectOfType<GameManager>().distance;
        // obstacles = new GameObject[6];
        gameManager = FindObjectOfType<GameManager>();

        //  for (int i = 0; i < this.transform.childCount; ++i){
        //      obstacles[i] = transform.GetChild(i).gameObject;
        //  }

        //Activate Again Block Which Disabled

        obstacles[numberOne].SetActive(true);
        obstacles[numberTwo].SetActive(true);

        int random = Random.Range(0,6);
        int random2 = Random.Range(0,6);

        while(!canBeDuo && (random-1==random2 || random2-1==random)){
            random2 = Random.Range(0,6);
        }

        while(random==random2){
            random2 = Random.Range(0,6);
        }

        numberOne = random;
        numberTwo = random2;

        obstacles[random].SetActive(false);
        obstacles[random2].SetActive(false);

    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            float score = (int)(player.transform.position.z/2);

            if(score>75 && score<150){
                canBeDuo=true;
                player.GetComponent<PlayerMovement>().forwardForce +=70;
                player.GetComponent<PlayerMovement>().turnForce +=.4f;
                gameManager.distance+=1.3f;
            }else if(score>150 && score<500){
                canBeDuo=false;
                player.GetComponent<PlayerMovement>().forwardForce +=40;
                player.GetComponent<PlayerMovement>().turnForce +=.3f;
                gameManager.distance+=1.5f;
            }else if(score>500 && score<1000){
                canBeDuo=false;
                player.GetComponent<PlayerMovement>().forwardForce +=20;
                player.GetComponent<PlayerMovement>().turnForce +=.3f;
                gameManager.distance+=1.5f;
            }
            else if(score>1000){
                canBeDuo=true;
                player.GetComponent<PlayerMovement>().forwardForce +=5;
                 player.GetComponent<PlayerMovement>().turnForce +=.1f;
                gameManager.distance+=1.5f;
            }

            Instantiate(prefabsObsStage,transform.position + new Vector3(0,0,distance),Quaternion.identity);
            Destroy(this.gameObject,1f);
        }
    }
}
