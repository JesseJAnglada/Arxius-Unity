using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{
    public GameObject Objeto;
    public AudioSource Sonido;

    void OnTriggerEnter(){
        GetComponent<BoxCollider>().enabled = false;
        Objeto.GetComponent<Animation>().Play("JumpScare1");
        Sonido.Play();
    }
}
