using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CogerLinterna : MonoBehaviour
{
//Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Linterna_Suelo;
    public GameObject LuzLinterna_Suelo;
    public GameObject Linterna_Personaje;
    public GameObject ExtraCross;
    public GameObject Pistola;
    public GameObject Mecanicas;
    public GameObject TextoMecanicas;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Agafar llanterna";
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
                Inventario.Linterna = true;
                if(Inventario.Pistola == true){
                    Pistola.SetActive(false);
                }
                Linterna_Suelo.GetComponent<MeshRenderer>().enabled = false;
                LuzLinterna_Suelo.SetActive(false);
                Linterna_Personaje.SetActive(true);
                StartCoroutine(Botones());
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator Botones(){
        Mecanicas.SetActive(true);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="F per encendre i apagar la llanterna.";
        yield return new WaitForSeconds(5);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="ScrollWheel del ratolí per canviar l'objecte.";
        yield return new WaitForSeconds(5);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="";
        Mecanicas.SetActive(false);
        Linterna_Suelo.SetActive(false);
    }
}
