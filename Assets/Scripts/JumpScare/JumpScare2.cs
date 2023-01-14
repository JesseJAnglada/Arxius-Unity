using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare2 : MonoBehaviour
{
    public GameObject Objeto;
    public AudioSource Sonido;

    void OnTriggerEnter(){
        GetComponent<BoxCollider>().enabled = false;
        Objeto.GetComponent<Animation>().Play("JumpScare2");
        Sonido.Play();
    }
}
