using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class MuerteGhoul : MonoBehaviour
{
    public int VidaEnemigo = 20;
    public GameObject Enemigo;
    public GameObject Fuego;
    public int StatusCheck;
    public AudioSource musicaAtaque;
    public AudioSource Ambiente1;
    public AudioSource Ambiente2;
    public AudioSource Ambiente3;
    public AudioSource Gruñido;
    public AudioSource SonidoMuerte;
    public int AmbienteAzar;
    public GameObject LlaveGhoul;
    public GameObject TextBox;
    public GameObject ActivadorExtintores;
    public AudioSource Voz8;


    void DañoZombie(int CantidadDaño){
        VidaEnemigo -= CantidadDaño;
    }

    void Update()
    {
        if(VidaEnemigo <= 0 && StatusCheck == 0){
            Fuego.SetActive(false);
            this.GetComponent<Ghoul_IA_Recepcion>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.GetComponent<Rigidbody>());
            Ghoul_IA_Recepcion.ZombieAgente.GetComponent<NavMeshAgent>().isStopped = true;
            StatusCheck = 2;
            Gruñido.Stop();
            SonidoMuerte.Play();
            Enemigo.GetComponent<Animator>().Play("Death");
            musicaAtaque.Stop();
            AmbienteAzar = BandaSonora.BSAzar;
            if(AmbienteAzar == 1){
                Ambiente1.Play();
            } else if(AmbienteAzar == 2){
                Ambiente2.Play();
            } else if(AmbienteAzar == 3){
                Ambiente3.Play();
            }
            StartCoroutine(Llave3());
        }    
    }

    IEnumerator Llave3(){
        yield return new WaitForSeconds(1);
        LlaveGhoul.SetActive(true);

        yield return new WaitForSeconds(1);
        TextBox.GetComponent<TextMeshProUGUI>().text="Sembla que ha caigut alguna cosa.";
        Voz8.Play();
        TextBox.SetActive(true);

        yield return new WaitForSeconds (2);
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);
        ActivadorExtintores.SetActive(true);
    }
}
