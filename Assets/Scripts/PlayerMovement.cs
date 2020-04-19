using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance {get;set;}
    public Rigidbody rigidBody;

    public float forwardForce=2000f,turnForce=500f;
    // Start is called before the first frame update
    // Update is called once per frame

    public bool goRight=false,goLeft=false;
    
    void Awake() {
        if(Instance==null){
            Instance=this;
        }
    }
    void FixedUpdate()
    {
        if(GetComponent<Transform>().position.y<.95){
            FindObjectOfType<GameManager>().EndGame();
        }
        //Set Drag 1
        //Add Fog
        rigidBody.AddForce(0,0,forwardForce * Time.deltaTime);

        if(goLeft || Input.GetKey("a")){
            rigidBody.AddForce(-turnForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }else if(goRight|| Input.GetKey("d")){
            rigidBody.AddForce(turnForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
    }

    //  void FixedUpdate()
    // {
    //     if(GetComponent<Transform>().position.y<.95){
    //         FindObjectOfType<GameManager>().EndGame();
    //     }
    //     //Set Drag 1
    //     //Add Fog
    //     rigidBody.AddForce(0,0,forwardForce * Time.deltaTime);

    //     if(Input.GetKey("a")){
    //         rigidBody.AddForce(-turnForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
    //     }
    //     if(Input.GetKey("d")){
    //         rigidBody.AddForce(turnForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
    //     }
    // }
}
