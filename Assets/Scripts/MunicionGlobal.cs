using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MunicionGlobal : MonoBehaviour
{

    public static int MunicionCantidad;
    public GameObject Municion;
    public int MunicionInterna;

    void Update()
    {
        MunicionInterna = MunicionCantidad;
        Municion.GetComponent<TextMeshProUGUI>().text = "" + MunicionCantidad;
    }
}
