using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverToMain : MonoBehaviour
{

    void Start()
    {
        VidaGeneral.VidaActual = 20;
        StartCoroutine(CreditosAMenu());
    }

    IEnumerator CreditosAMenu(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

}
