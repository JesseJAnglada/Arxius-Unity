using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorCellOpen : MonoBehaviour
{

    //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Puerta;
    public AudioSource SonidoPuerta;
    public GameObject ExtraCross;
    public GameObject PuertaCerrada;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo a la puerta
        Distancia = Player_Casting.DistanceFromTarget;

    }

    //Creamos void para activar la animacion de la puerta con el raton sobre ella
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive (true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Obrir";
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                Puerta.GetComponent<Animation>().Play("Puerta1_Anim");
                SonidoPuerta.Play();
                if(PuertaCerrada){
                    PuertaCerrada.SetActive(false);
                }
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
