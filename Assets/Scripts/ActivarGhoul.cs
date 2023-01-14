using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGhoul : MonoBehaviour
{
    public GameObject GhoulActivo;
    public GameObject GhoulNoActivo;
    public AudioSource Persecucion;
    public AudioSource Ambiente1;
    public AudioSource Ambiente2;
    public AudioSource Ambiente3;
    public int AmbienteAzar;
    void OnTriggerEnter(){
        if(GhoulIA.Persigue == false){
            GhoulActivo.SetActive(false);
            GhoulNoActivo.SetActive(true);
            GhoulIA.Persigue = true;
            AmbienteAzar = BandaSonora.BSAzar;
            if(AmbienteAzar == 1){
                Ambiente1.Stop();
            } else if(AmbienteAzar == 2){
                Ambiente2.Stop();
            } else if(AmbienteAzar == 3){
                Ambiente3.Stop();
            }
            Persecucion.Play();
        }
        else{
            GhoulNoActivo.SetActive(false);
            GhoulActivo.SetActive(true);
            GhoulIA.Persigue = false;
            Persecucion.Stop();
            AmbienteAzar = BandaSonora.BSAzar;
            if(AmbienteAzar == 1){
                Ambiente1.Play();
            } else if(AmbienteAzar == 2){
                Ambiente2.Play();
            } else if(AmbienteAzar == 3){
                Ambiente3.Play();
            }
        }
  }
}
