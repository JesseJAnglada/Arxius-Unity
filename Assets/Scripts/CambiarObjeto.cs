using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarObjeto : MonoBehaviour
{
    public GameObject Linterna;
    public GameObject Pistola;
    public bool Objeto = false;
    public float rueda;

    void Update()
    {
        rueda = Input.GetAxis("Mouse ScrollWhell");
        if(rueda > 0 || rueda < 0){

            if (Inventario.Pistola == true && Objeto == false){
                Linterna.SetActive(false);
                Pistola.SetActive(true);
                Objeto = true;
            }else if(Inventario.Linterna == true && Objeto == true){
                Pistola.SetActive(false);
                Linterna.SetActive(true);
                Objeto = false;
            }
        }
    }
}
