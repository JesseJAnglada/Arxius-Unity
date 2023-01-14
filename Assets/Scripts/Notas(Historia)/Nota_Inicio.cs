using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;


public class Nota_Inicio : MonoBehaviour
{

        //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Nota;
    public GameObject Flecha;
    public AudioSource SonidoPapel;
    public GameObject ExtraCross;
    public GameObject FondoNota;
    public GameObject LeyendoNota;
    public GameObject Jugador;
    public GameObject TextBox;
    public GameObject Difuminado;
    public AudioSource Voz3;

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
                Flecha.SetActive(false);
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
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="Estimada Yara, no sé si arribaràs a llegir això algun dia, però ens hem vist obligats a abandonar el poble. L'augment de la violència i atacs caníbals per persones infectades pel virus fa que mantenir-nos aquí sigui massa perillós. Ens emportem la Nala amb nosaltres a la casa de la muntanya, sé el molt que t'importa. Si us plau, espero que superis el coma i et puguis reunir amb nosaltres. Amb amor, Denki.";
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        Inventario.Leyendo = false;
        FondoNota.SetActive(false);
        Difuminado.SetActive(false);
        LeyendoNota.GetComponent<TextMeshProUGUI>().text="";
        Jugador.GetComponent<FirstPersonController>().enabled = true;

        //Reaccion nota
        TextBox.GetComponent<TextMeshProUGUI>().text="Denki... Nala... He de sortir d'aquí.";
        Voz3.Play();
        TextBox.SetActive(true);
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);

    }

    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
