using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarZombie_Sala4 : MonoBehaviour
{
    public GameObject ZombieActivo;
    public GameObject ZombieNoActivo;
    
    void OnTriggerEnter(){
        if(ZombieIA_Sala4.Persigue == false){
            ZombieActivo.SetActive(false);
            ZombieNoActivo.SetActive(true);
            ZombieIA_Sala4.Persigue = true;
        }
        else{
            ZombieNoActivo.SetActive(false);
            ZombieActivo.SetActive(true);
            ZombieIA_Sala4.Persigue = false;
        }
  }
}
