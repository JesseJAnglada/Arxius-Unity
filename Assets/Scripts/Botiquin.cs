using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Botiquin : MonoBehaviour
{
    public float Distancia;
    public GameObject ExtraCross;
    public GameObject ActionText;
    public GameObject ActionDisplay;
    public GameObject ObjetoBotiquin;
    public AudioSource SonidoBotiquin;
    public GameObject TextBox;
    public AudioSource Voz18;
        void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Agafar farmaciola";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(CogerBotiquin());                
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator CogerBotiquin(){
        if(VidaGeneral.VidaActual < 20){
            VidaGeneral.VidaActual += 5;
            ObjetoBotiquin.SetActive(false);
            SonidoBotiquin.Play(); 
        }else{
            TextBox.SetActive(true);
            TextBox.GetComponent<TextMeshProUGUI>().text = "Ara no necessito curar-me.";
            Voz18.Play();
            yield return new WaitForSeconds(2);
            TextBox.SetActive(false);
            TextBox.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
