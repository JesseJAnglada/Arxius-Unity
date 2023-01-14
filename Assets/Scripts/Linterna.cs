using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
public GameObject LuzLinterna;
public AudioSource Clic;
public bool Encendida = true;

    void Update()
    {
        if(Input.GetButtonDown("Linterna")){
            Clic.Play();
            if(Encendida == true){
                LuzLinterna.GetComponent<Light>().enabled = false;
                Encendida = false;
            }else{
                LuzLinterna.GetComponent<Light>().enabled = true;
                Encendida = true;
            }
        }
    }
}
