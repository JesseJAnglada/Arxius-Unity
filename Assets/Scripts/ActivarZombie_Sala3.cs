using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarZombie_Sala3 : MonoBehaviour
{
    public GameObject ZombieActivo;
    public GameObject ZombieNoActivo;
    
    void OnTriggerEnter(){
        if(ZombieIA_Sala3.Persigue == false){
            ZombieActivo.SetActive(false);
            ZombieNoActivo.SetActive(true);
            ZombieIA_Sala3.Persigue = true;
        }
        else{
            ZombieNoActivo.SetActive(false);
            ZombieActivo.SetActive(true);
            ZombieIA_Sala3.Persigue = false;
        }
  }
}
