using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasos : MonoBehaviour
{
CharacterController cc;
public AudioSource SonidoPasos, SonidoSprint;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude >2f && SonidoPasos.isPlaying == false){
            if(SonidoSprint.isPlaying == true && Input.GetButtonUp("Sprint")){
                SonidoSprint.Stop();
            }
            SonidoPasos.Play();

        }else if(cc.isGrounded == true && cc.velocity.magnitude >2f && SonidoSprint.isPlaying == false && Input.GetButton("Sprint")){
            if(SonidoPasos.isPlaying == true){
                SonidoPasos.Stop();
            }
            SonidoSprint.Play();
        }
    }
}
