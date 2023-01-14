using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MuerteZombie_Sala4 : MonoBehaviour
{
    public int VidaEnemigo = 20;
    public GameObject Enemigo;
    public int StatusCheck;
    public AudioSource Gruñido1;
    public AudioSource Gruñido2;
    public AudioSource Gruñido3;
    public int AzarGruñido;
    public AudioSource SonidoMuerte;
    public int AmbienteAzar;


    void DañoZombie(int CantidadDaño){
        VidaEnemigo -= CantidadDaño;
    }

    void Update()
    {
        if(VidaEnemigo <= 0 && StatusCheck == 0){
            this.GetComponent<ZombieIA_Sala4>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.GetComponent<Rigidbody>());
            if(ZombieIA_Sala4.ZombieAgente.GetComponent<NavMeshAgent>().isStopped == false){
                ZombieIA_Sala4.ZombieAgente.GetComponent<NavMeshAgent>().isStopped = true;
            }
            StatusCheck = 2;
            AzarGruñido = ZombieIA_Sala4.GruñidoAzar;
            if(AzarGruñido == 1){
                Gruñido1.Stop();
            }else if(AzarGruñido == 2){
                Gruñido2.Stop();
            }else if(AzarGruñido == 3){
                Gruñido3.Stop();
            }
            SonidoMuerte.Play();
            Enemigo.GetComponent<Animator>().Play("Z_FallingForward");
        }
    }    
    
}
