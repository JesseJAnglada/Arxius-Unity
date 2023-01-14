using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class GhoulIA : MonoBehaviour
{
    public GameObject ObjetivoGhoul;
    NavMeshAgent AgenteGhoul;
    public GameObject EnemigoGhoul;
    public GameObject SpawnGhoul;
    public static bool Spawn;
    public static bool Persigue;
    public  bool Ataque = false;
    public  bool GhoulAtaca = false;
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
        AgenteGhoul = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other){
        if(Persigue == false){
            Spawn = true;
        }

        if(Persigue == true && other.gameObject.tag == "Player"){
            Ataque = true;
        }
    }
    void OnTriggerExit(Collider other){
       if(Persigue == true){
            Spawn = false;
        }
        if(other.gameObject.tag == "Player"){
            Ataque = false;
        }
    }

    void Update()
    {
        //verSpawn = Spawn;
        //verPersigue = Persigue;
        if(Persigue == false){
            SpawnGhoul.GetComponent<BoxCollider>().enabled = true;
            if(Spawn == true){
                AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = true;
                EnemigoGhoul.GetComponent<Animator>().Play("Idle");

            }

            if(Spawn == false){
                SpawnGhoul.SetActive(true);
                AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = false;
                EnemigoGhoul.GetComponent<Animator>().Play("Walk");
                AgenteGhoul.SetDestination(SpawnGhoul.transform.position);
                
            }

        } else{
            SpawnGhoul.SetActive(false);
            SpawnGhoul.GetComponent<BoxCollider>().enabled = false;

        }

        if(Persigue == true && Ataque == false){
            AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = false;
            EnemigoGhoul.GetComponent<Animator>().Play("Walk");
            AgenteGhoul.SetDestination(ObjetivoGhoul.transform.position);
        }

        if(Persigue == true && Ataque == true && GhoulAtaca == false){
            AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = true;
            EnemigoGhoul.GetComponent<Animator>().Play("Attack1");
            StartCoroutine(DañoGhoul());
        }
    }

    IEnumerator DañoGhoul(){
        GhoulAtaca = true;
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
            yield return new WaitForSeconds(0.1f);
            Sangrado_Golpe.SetActive(false);
            Arañazo1.SetActive(false);            
        }else if(ArañazoAzar == 2){
            Sangrado_Golpe.SetActive(true);
            Arañazo2.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Sangrado_Golpe.SetActive(false);
            Arañazo2.SetActive(false);
        } else if(ArañazoAzar == 3){
            Sangrado_Golpe.SetActive(true);
            Arañazo3.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Sangrado_Golpe.SetActive(false);
            Arañazo3.SetActive(false);
        }

        VidaGeneral.VidaActual -= 5;

        yield return new WaitForSeconds(1.3f);
        GhoulAtaca = false;
    }
}
