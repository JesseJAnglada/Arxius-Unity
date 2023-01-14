using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuegoRecepcion : MonoBehaviour
{
 //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TextBox;
    public GameObject ExtraCross;
    public AudioSource FuegoApagado;
    public AudioSource SonidoExtintor;
    public GameObject Fuego;
    //public GameObject Extintor;
    public GameObject Humo;
    public GameObject ActivadorFinal;
    public GameObject Bloqueador;
    public AudioSource Voz9;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Apagar";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(ApagarFuego());
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator ApagarFuego(){
        if(Inventario.Extintor == false){
        TextBox.SetActive(true);
        TextBox.GetComponent<TextMeshProUGUI>().text = "Necessito alguna cosa per apagar-lo.";
        Voz9.Play();
        yield return new WaitForSeconds(2);
        TextBox.SetActive(false);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        }
        else{
            SonidoExtintor.Play();
            Humo.SetActive(true);
            yield return new WaitForSeconds(3);
            SonidoExtintor.Stop();
            FuegoApagado.Play();
            Fuego.SetActive(false);
            //Bloqueador.SetActive(false);
            ActivadorFinal.SetActive(true);
        }
    }
}
