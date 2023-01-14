using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Intro_UOC : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(IntroAMenu());
    }

    IEnumerator IntroAMenu(){
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }

}
