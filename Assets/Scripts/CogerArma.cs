using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CogerArma : MonoBehaviour
{

    //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Pistola_Suelo;
    public GameObject Pistola_Personaje;
    public GameObject Flecha;
    public GameObject ExtraCross;
    public GameObject Activador_Ataque;
    public GameObject MunicionHUD;
    public AudioSource CogerPistola;
    public GameObject Mecanicas;
    public GameObject TextoMecanicas;
    public GameObject PuertaCerrada;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Agafar arma";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                Pistola_Suelo.GetComponent<MeshRenderer>().enabled = false;
                Pistola_Personaje.SetActive(true);
                ExtraCross.SetActive(false);
                Activador_Ataque.SetActive(true);
                MunicionHUD.SetActive(true);
                Flecha.SetActive(false);
                CogerPistola.Play();
                Inventario.Pistola = true;
                PuertaCerrada.SetActive(false);
                StartCoroutine(Boton());
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator Boton(){
        Mecanicas.SetActive(true);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="Clic Esquerre per disparar.";
        yield return new WaitForSeconds(5);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="";
        Mecanicas.SetActive(false);
        Pistola_Suelo.SetActive(false);
    }
}
