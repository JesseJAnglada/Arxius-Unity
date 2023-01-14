using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class A_Inicio001 : MonoBehaviour
{
    //Variables para hacer intro
    public GameObject Jugador;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public GameObject Mecanicas;
    public GameObject TextoMecanicas;
    public AudioSource Voz1;


    void Start()
    {
        //Desactivamos controles primera persona y comenzamos escena
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Jugador.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());   
    }

    IEnumerator ScenePlayer(){
        FadeScreenIn.SetActive(true);
        yield return new WaitForSeconds (1.5f);
        FadeScreenIn.SetActive(false);

        //Iniciamos texto escena inicio en la textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="Deu meu... Què ha passat...?";
        Voz1.Play();
        TextBox.SetActive(true);

        yield return new WaitForSeconds (3);
        
        //vaciamos textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);

        //activamos controles primera persona
        Jugador.GetComponent<FirstPersonController>().enabled = true;
        Mecanicas.SetActive(true);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="WASD per moure't.";
        yield return new WaitForSeconds(5);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="Barra Espaciadora per saltar.";
        yield return new WaitForSeconds(5);
        TextoMecanicas.GetComponent<TextMeshProUGUI>().text="";
        Mecanicas.SetActive(false);

    }


}
