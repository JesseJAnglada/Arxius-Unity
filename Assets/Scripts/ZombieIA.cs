using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIA : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Enemigo;
    public float velocidadEnemigo = 1.5f;
    public bool activadorAtaque = false;
    public bool zombieAtaca = false;
    public AudioSource Herida1;
    public AudioSource Herida2;
    public AudioSource Herida3;
    public AudioSource Gruñido1;
    public AudioSource Gruñido2;
    public AudioSource Gruñido3;
    public static int GruñidoAzar;
    public bool Gruñe = false;
    public AudioSource Ataque;
    public int HeridaAzar;
    public GameObject Sangrado_Golpe;
    public int ArañazoAzar;
    public GameObject Arañazo1;
    public GameObject Arañazo2;
    public GameObject Arañazo3;

    void Update()
    {
        transform.LookAt(Jugador.transform);
        if(activadorAtaque == false){
            StartCoroutine(GemidoZombie());
            Gruñe = true;
            velocidadEnemigo = 2.5f;
            Enemigo.GetComponent<Animator>().Play("Z_Walk_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, velocidadEnemigo * Time.deltaTime);
        }

        if(activadorAtaque == true && zombieAtaca == false){
            velocidadEnemigo = 0;
            if(GruñidoAzar == 1){
                Gruñido1.Stop();
            }else if(GruñidoAzar == 2){
                Gruñido2.Stop();
            }else if(GruñidoAzar == 3){
                Gruñido3.Stop();
            }
            Ataque.Play();
            Enemigo.GetComponent<Animator>().Play("Z_Attack");
            StartCoroutine(InflingeDaño());
        }
    }

    void OnTriggerEnter(){
        activadorAtaque = true;
    }

    void OnTriggerExit(){
        activadorAtaque = false;
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
    IEnumerator InflingeDaño(){
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
