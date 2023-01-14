using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionFuego : MonoBehaviour
{
    public int AnimFuego;

    public GameObject Fuego;

    void Update(){
        if(AnimFuego == 0){
            StartCoroutine(TipoFuego());
        }
    }

    IEnumerator TipoFuego(){
        AnimFuego = Random.Range(1,4);

        if(AnimFuego == 1){
            Fuego.GetComponent<Animation>().Play("Fuego");
        }
        if(AnimFuego == 2){
            Fuego.GetComponent<Animation>().Play("Fuego2");
        }
        if(AnimFuego == 3){
            Fuego.GetComponent<Animation>().Play("Fuego3");
        }
        yield return new WaitForSeconds(0.9f);
        AnimFuego = 0;
    }
}
