using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    
    public static Buttons Instance {get;set;}

    void Awake() {
        if(Instance==null){
            Instance=this;
        }
    }

    public void GoRight(){
        Debug.Log("GoRight");

        PlayerMovement.Instance.goRight=true;
    }
    public void GoLeft(){
        Debug.Log("GoLeft");

        PlayerMovement.Instance.goLeft=true;
    }

    public void DontMove(){
        Debug.Log("Dont Move");
        PlayerMovement.Instance.goRight=false;
        PlayerMovement.Instance.goLeft=false;
    }
}
