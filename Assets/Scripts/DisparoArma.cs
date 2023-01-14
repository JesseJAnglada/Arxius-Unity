using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoArma : MonoBehaviour
{
   public GameObject Pistola;
   public GameObject FlashDisparo;
   public AudioSource SonidoDisparo;
   public AudioSource SinBalas;
   public bool Disparo = false;
   public float TargetDistance;
   public int CantidadDaño = 5;

    
    void Update()
    {
     if (Input.GetButtonDown("Fire1") && MunicionGlobal.MunicionCantidad >= 1 && Inventario.Leyendo == false && Pausa.isPaused == false){
        if(Disparo == false){
            MunicionGlobal.MunicionCantidad -= 1;
            StartCoroutine(FiringPistol());
        }
     }else if(Input.GetButtonDown("Fire1") && MunicionGlobal.MunicionCantidad == 0 && Inventario.Leyendo == false && Pausa.isPaused == false){
        SinBalas.Play();
     }   
    }

    IEnumerator FiringPistol(){
        RaycastHit Shot;
        Disparo = true;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DañoZombie", CantidadDaño, SendMessageOptions.DontRequireReceiver);
        }
        Pistola.GetComponent<Animation>().Play("Disparo_Pistola");
        FlashDisparo.SetActive(true);
        FlashDisparo.GetComponent<Animation>().Play("Flash_Disparo");
        SonidoDisparo.Play();
        yield return new WaitForSeconds(0.5f);
        Disparo = false;
        FlashDisparo.SetActive(false);
    }
}
