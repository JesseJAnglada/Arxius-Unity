using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_AtaqueRecepcion : MonoBehaviour
{
    public AudioSource GolpePuerta;
    public AudioSource MusicaAtaque;
    public GameObject TheGhoul;
    public GameObject Puerta1;
    public GameObject VisagraPuerta1;
    public GameObject VisagraPuerta2;
    //public GameObject Cerradura;
    public AudioSource Ambiente1;
    public AudioSource Ambiente2;
    public AudioSource Ambiente3;
    public AudioSource Gruñido;
    public int AmbienteAzar;
    public GameObject Fuego;
    public GameObject Humo;
    public AudioSource SonidoFuego;

    void OnTriggerEnter(){
        GetComponent<BoxCollider>().enabled = false;
        VisagraPuerta1.GetComponent<Animation>().Play("PuertaRecepcion1");
        VisagraPuerta2.GetComponent<Animation>().Play("PuertaRecepcion2");
        GolpePuerta.Play();
        TheGhoul.SetActive(true);
        Gruñido.Play();
        Puerta1.GetComponent<BoxCollider>().enabled = false;
        //Cerradura.SetActive(false);
        StartCoroutine(FuegoYMusica());
    }

    IEnumerator FuegoYMusica(){
        yield return new WaitForSeconds(0.4f);
        AmbienteAzar = BandaSonora.BSAzar;
        if(AmbienteAzar == 1){
            Ambiente1.Stop();
        } else if(AmbienteAzar == 2){                
            Ambiente2.Stop();
        } else if(AmbienteAzar == 3){
            Ambiente3.Stop();
        }
        MusicaAtaque.Play();
        yield return new WaitForSeconds(2);
        Fuego.SetActive(true);
        SonidoFuego.Play();
        yield return new WaitForSeconds(1.5f);
        Humo.SetActive(true);
    }
}
