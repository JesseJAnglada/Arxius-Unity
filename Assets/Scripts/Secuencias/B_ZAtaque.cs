using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class B_ZAtaque : MonoBehaviour
{
    public AudioSource GolpePuerta;
    public AudioSource MusicaPrimerAtaque;
    public GameObject TheZombie;
    public GameObject TheDoor;
    public AudioSource Ambiente1;
    public AudioSource Ambiente2;
    public AudioSource Ambiente3;
    public int AmbienteAzar;
    //public GameObject PuertaCerrada;


    void OnTriggerEnter(){
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("PuertaAbajo");
        GolpePuerta.Play();
        TheZombie.SetActive(true);
        TheDoor.GetComponent<BoxCollider>().enabled = false;
        //PuertaCerrada.SetActive(false);
        StartCoroutine(PlayMusicaPrimerAtaque());
    }

    IEnumerator PlayMusicaPrimerAtaque(){
        yield return new WaitForSeconds(0.4f);
        AmbienteAzar = BandaSonora.BSAzar;
            if(AmbienteAzar == 1){
                Ambiente1.Stop();
            } else if(AmbienteAzar == 2){
                Ambiente2.Stop();
            } else if(AmbienteAzar == 3){
                Ambiente3.Stop();
            }
        MusicaPrimerAtaque.Play();
    }
}
