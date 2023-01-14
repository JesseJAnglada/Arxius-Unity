using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandaSonora : MonoBehaviour
{
public static int BSAzar;
public AudioSource Ambiente1;
public AudioSource Ambiente2;
public AudioSource Ambiente3;
    void Start()
    {
        BSAzar = Random.Range(1,4);
        if(BSAzar == 1){
            Ambiente1.Play();
        } else if(BSAzar == 2){
            Ambiente2.Play();
        } else if(BSAzar == 3){
            Ambiente3.Play();
        }
    }

}
