using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Casting : MonoBehaviour{
   
   //Clases Script
   public static float DistanceFromTarget;
   public float ToTarget;


    void Update(){
        //Calcula distancia con objetivo
        RaycastHit Hit;
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
