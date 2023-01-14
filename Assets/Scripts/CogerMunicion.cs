using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CogerMunicion : MonoBehaviour
{
    public float Distancia;
    public GameObject ExtraCross;
    public GameObject ActionText;
    public GameObject ActionDisplay;
    public GameObject Municion;
    public AudioSource SonidoMunicion;

        void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Agafar munició";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                Municion.SetActive(false);
                SonidoMunicion.Play();
                MunicionGlobal.MunicionCantidad += 7;
                ExtraCross.SetActive(false);
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
