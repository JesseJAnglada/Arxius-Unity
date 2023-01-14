using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class Ghoul_IA_Recepcion : MonoBehaviour
{
    public GameObject ObjetivoZombie;
    NavMeshAgent AgenteZombie;
    public static NavMeshAgent ZombieAgente;
    public GameObject EnemigoZombie;
    public  bool Ataque = false;
    public  bool zombieAtaca = false;
    public AudioSource Herida1;
    public AudioSource Herida2;
    public AudioSource Herida3;
    public int HeridaAzar;
    public GameObject Sangrado_Golpe;
    public int ArañazoAzar;
    public GameObject Arañazo1;
    public GameObject Arañazo2;
    public GameObject Arañazo3;


    //public bool verSpawn;
    //public bool verPersigue;

    void Start()
    {
        AgenteZombie = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Ataque = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            Ataque = false;
        }
    }

    void Update()
    {
        //verSpawn = Spawn;
        //verPersigue = Persigue;
        ZombieAgente = AgenteZombie;

        if(Ataque == false){
            AgenteZombie.GetComponent<NavMeshAgent>().isStopped = false;
            EnemigoZombie.GetComponent<Animator>().Play("Run");
            AgenteZombie.SetDestination(ObjetivoZombie.transform.position);
        }

        if(Ataque == true && zombieAtaca == false){
            AgenteZombie.GetComponent<NavMeshAgent>().isStopped = true;
            EnemigoZombie.GetComponent<Animator>().Play("Attack2");
            StartCoroutine(DañoGhoul());
        }
    }

    IEnumerator DañoGhoul(){
        zombieAtaca = true;
        HeridaAzar = Random.Range(1, 4);

        if(HeridaAzar == 1){
            Herida1.Play();
        }else if(HeridaAzar == 2){
            Herida2.Play();
        } else if(HeridaAzar == 3){
            Herida3.Play();
        }

        ArañazoAzar = Random.Range(1, 4);

        if(ArañazoAzar == 1){
            Sangrado_Golpe.SetActive(true);
            Arañazo1.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            Sangrado_Golpe.SetActive(false);
            Arañazo1.SetActive(false);            
        }else if(ArañazoAzar == 2){
            Sangrado_Golpe.SetActive(true);
            Arañazo2.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            Sangrado_Golpe.SetActive(false);
            Arañazo2.SetActive(false);
        } else if(ArañazoAzar == 3){
            Sangrado_Golpe.SetActive(true);
            Arañazo3.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            Sangrado_Golpe.SetActive(false);
            Arañazo3.SetActive(false);
        }

        VidaGeneral.VidaActual -= 5;

        yield return new WaitForSeconds(1.3f);
        zombieAtaca = false;
    }
}
