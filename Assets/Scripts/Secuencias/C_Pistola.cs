using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class C_Pistola : MonoBehaviour
{
    //Variables para la secuencia
    public GameObject Jugador;
    public GameObject TextBox;
    public GameObject Flecha;
    public GameObject Activador;
    public AudioSource Pasos;
    public AudioSource Sprint;
    public AudioSource Voz5;

    void OnTriggerEnter()
    {
        //Desactivamos controles primera persona y comenzamos escena
        /*Jugador.GetComponent<FirstPersonController>().enabled = false;
        Pasos.volume = 0;
        Sprint.volume = 0;*/
        Activador.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(EscenaPistola()); 
    }

    IEnumerator EscenaPistola(){

        //Iniciamos texto escena inicio en la textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="Em fa la sensació que necessitaré allò.";
        Voz5.Play();
        TextBox.SetActive(true);

        //activamos flecha
        Flecha.SetActive (true);

        yield return new WaitForSeconds (2.5f);
        
        //vaciamos textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);

        //activamos controles primera persona
        /*Jugador.GetComponent<FirstPersonController>().enabled = true;
        Pasos.volume = 0.25f;
        Sprint.volume = 0.3f;*/

        //desactivamos activador para que no vuelva a salir mensaje
        Activador.SetActive(false);
    }
    
}
