using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;


public class Nota_Sala2 : MonoBehaviour
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
    public AudioSource Voz6;

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
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="S'han identificat dos tipus diferents de mutacions: els 'Zombis Normals' i les bèsties a les quals anomenem 'Alfa'. Els exemplars normals poden ser eliminats amb armes de foc comunes. En canvi, els 'Alfa' no pateixen cap mena de ferida, però, mostren debilitat al foc. Sembla que les altes temperatures els fa vulnerables.";
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        Inventario.Leyendo = false;
        FondoNota.SetActive(false);
        Difuminado.SetActive(false);
        Indicador.SetActive(false);
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="";
        Jugador.GetComponent<FirstPersonController>().enabled = true;

        //Reaccion nota
        TextBox.GetComponent<TextMeshProUGUI>().text="Així que la bèstia que tenen tancada només es torna vulnerable amb foc...";
        Voz6.Play();
        TextBox.SetActive(true);
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
