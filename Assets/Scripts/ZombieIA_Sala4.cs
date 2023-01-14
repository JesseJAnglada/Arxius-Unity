using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class ZombieIA_Sala4 : MonoBehaviour
{
    public GameObject ObjetivoZombie;
    NavMeshAgent AgenteZombie;
    public static NavMeshAgent ZombieAgente;
    public GameObject EnemigoZombie;
    public GameObject SpawnZombie;
    public static bool Spawn;
    public static bool Persigue;
    public  bool Ataque = false;
    public  bool zombieAtaca = false;
    public AudioSource Herida1;
    public AudioSource Herida2;
    public AudioSource Herida3;
    public int HeridaAzar;
    public GameObject Sangrado_Golpe;
    public AudioSource Gruñido1;
    public AudioSource Gruñido2;
    public AudioSource Gruñido3;
    public static int GruñidoAzar;
    public bool Gruñe = false;
    public AudioSource SonidoAtaque;
    public int ArañazoAzar;
    public GameObject Arañazo1;
    public GameObject Arañazo2;
    public GameObject Arañazo3;


    //public bool verSpawn;
    //public bool verPersigue;

    void Start()
    {
        AgenteZombie = GetComponent<NavMeshAgent>();
        EnemigoZombie.GetComponent<Animator>().Play("Z_FallingBack");
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
    if(Inventario.FaseFinal == true){
        ZombieAgente = AgenteZombie;
        StartCoroutine(GemidoZombie());
        Gruñe = true;
        if(Persigue == false){
            SpawnZombie.GetComponent<BoxCollider>().enabled = true;
            if(Spawn == true){
                AgenteZombie.GetComponent<NavMeshAgent>().isStopped = true;
                EnemigoZombie.GetComponent<Animator>().Play("Z_Idle");

            }

            if(Spawn == false){
                SpawnZombie.SetActive(true);
                AgenteZombie.GetComponent<NavMeshAgent>().isStopped = false;
                AgenteZombie.speed = 2;
                EnemigoZombie.GetComponent<Animator>().Play("Z_Walk1_InPlace");
                AgenteZombie.SetDestination(SpawnZombie.transform.position);
                
            }

        } else{
            SpawnZombie.SetActive(false);
            SpawnZombie.GetComponent<BoxCollider>().enabled = false;

        }

        if(Persigue == true && Ataque == false){
            AgenteZombie.GetComponent<NavMeshAgent>().isStopped = false;
            EnemigoZombie.GetComponent<Animator>().Play("Z_Run_InPlace");
            AgenteZombie.speed = 5;
            AgenteZombie.SetDestination(ObjetivoZombie.transform.position);
        }

        if(Persigue == true && Ataque == true && zombieAtaca == false){
            AgenteZombie.GetComponent<NavMeshAgent>().isStopped = true;
            if(GruñidoAzar == 1){
                Gruñido1.Stop();
            }else if(GruñidoAzar == 2){
                Gruñido2.Stop();
            }else if(GruñidoAzar == 3){
                Gruñido3.Stop();
            }
            SonidoAtaque.Play();
            EnemigoZombie.GetComponent<Animator>().Play("Z_Attack");
            StartCoroutine(DañoGhoul());
        }
    }
    }

    IEnumerator GemidoZombie(){
        GruñidoAzar = Random.Range(1,4);
        yield return new WaitWhile(()=> Gruñe);
            if(GruñidoAzar == 1){
                Gruñido1.Play();
                yield return new WaitForSeconds(3);
                Gruñe = false;
            }else if(GruñidoAzar == 2){
                Gruñido2.Play();
                yield return new WaitForSeconds(3);
                Gruñe = false;
            }else if(GruñidoAzar == 3){
                Gruñido3.Play();
                yield return new WaitForSeconds(3);
                Gruñe = false;
            }
        yield return new WaitForSeconds(3);
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
