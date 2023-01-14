using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CogerExtintor : MonoBehaviour
{
//Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject ExtintorLleno;
    public GameObject TextBox;
    public GameObject ExtintorVacio;
    public GameObject ExtintorPesado;
    public AudioSource GuardarExtintor;
    public AudioSource Vacio;
    public GameObject ActivadorZombie;
    public AudioSource Voz13, Voz14, Voz15;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Agafar Extintor";
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
                StartCoroutine(ExtintorNoValido());
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator ExtintorNoValido(){
        if(ExtintorVacio){
            Vacio.Play();
            yield return new WaitForSeconds(1.8f);
            Vacio.Stop();
            TextBox.SetActive(true);
            TextBox.GetComponent<TextMeshProUGUI>().text = "Aquest és buit.";
            Voz13.Play();
            yield return new WaitForSeconds(2);
            TextBox.SetActive(false);
            TextBox.GetComponent<TextMeshProUGUI>().text = "";
            this.GetComponent<BoxCollider>().enabled = true;
        }else if(ExtintorPesado){
            TextBox.SetActive(true);
            TextBox.GetComponent<TextMeshProUGUI>().text = "No puc carregar amb això.";
            Voz14.Play();
            yield return new WaitForSeconds(2);
            TextBox.SetActive(false);
            TextBox.GetComponent<TextMeshProUGUI>().text = "";
            this.GetComponent<BoxCollider>().enabled = true;
        }else{
            ExtintorLleno.SetActive(false);
            GuardarExtintor.Play();
            Inventario.Extintor = true;
            Inventario.FaseFinal = true;
            yield return new WaitForSeconds(0.5f);
            TextBox.SetActive(true);
            TextBox.GetComponent<TextMeshProUGUI>().text = "Hora de sortir d'aquí!";
            Voz15.Play();
            yield return new WaitForSeconds(2);
            TextBox.SetActive(false);
            TextBox.GetComponent<TextMeshProUGUI>().text = "";
            ActivadorZombie.SetActive(true);
        }
    }
}
