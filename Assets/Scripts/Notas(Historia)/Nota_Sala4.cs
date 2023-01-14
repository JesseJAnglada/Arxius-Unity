using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;


public class Nota_Sala4 : MonoBehaviour
{

        //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Nota;
    public AudioSource SonidoPapel;
    public GameObject ExtraCross;
    public GameObject FondoNota;
    public GameObject LeyendoNota;
    public GameObject Jugador;
    public GameObject TextBox;
    public GameObject Difuminado;
    public GameObject Indicador;
    public AudioSource Voz11, Voz12;


    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo a la  nota
        Distancia = Player_Casting.DistanceFromTarget;
    }

    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                this.GetComponent<BoxCollider>().enabled = false;
                Nota.GetComponent<MeshRenderer>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                SonidoPapel.Play();
                StartCoroutine(Lectura());
            }
        }
    }
    //Contenido de la nota con pausa de los movimientos del personaje
    IEnumerator Lectura(){
        //Lectura nota
        Inventario.Leyendo = true;
        Jugador.GetComponent<FirstPersonController>().enabled = false;
        FondoNota.SetActive(true);
        Difuminado.SetActive(true);
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="Es demana a tot el personal assignat al laboratori que esperi pel seu transport a l'entrada del recinte. Els vehicles de transport es troben aparcats a prop de l'edifici i es requerirà mostrar l'acreditació pertinent.";
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        Inventario.Leyendo = false;
        FondoNota.SetActive(false);
        Difuminado.SetActive(false);
        Indicador.SetActive(false);
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="";
        Jugador.GetComponent<FirstPersonController>().enabled = true;

        //Reaccion nota
        TextBox.GetComponent<TextMeshProUGUI>().text="Un vehicle facilitaria el desplaçament fins a la casa de la muntanya...";
        Voz11.Play();
        TextBox.SetActive(true);
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<TextMeshProUGUI>().text="No crec que en aquesta situació em faci falta una acreditació.";
        Voz12.Play();
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);
        Nota.SetActive(false);


    }

    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
