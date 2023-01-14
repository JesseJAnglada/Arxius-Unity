using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaGeneral : MonoBehaviour
{
    public static int VidaActual = 20;
    public int VidaInterna;
    public GameObject VidaObject;
    public GameObject Vida1;
    public GameObject Vida2;
    public GameObject Vida3;
    public AudioSource Latido;

    void Update()
    {
        VidaInterna = VidaActual;

        if(VidaActual == 20){
            VidaObject.SetActive(false);
            Vida3.SetActive(false);
            if(Latido.isPlaying == true){
                Latido.Stop();
            }
        }
        if(VidaActual == 15){
            VidaObject.SetActive(true);
            Vida2.SetActive(false);
            Vida1.SetActive(true);
            Latido.pitch = 1;
            if(Latido.isPlaying == false){
                Latido.Play();
            }
        }
        if(VidaActual == 10){
            Vida3.SetActive(false);
            Vida2.SetActive(true);
            Vida1.SetActive(false);
            Latido.pitch = 1.5f;
        }
        if(VidaActual == 5){
            Vida3.SetActive(true);
            Vida2.SetActive(false);
            Latido.pitch = 2;
        }
        if(VidaActual <= 0){
            SceneManager.LoadScene(3);
        }
    }
}
