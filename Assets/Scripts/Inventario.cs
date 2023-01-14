using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static bool LlaveJardin = false;
    public static bool LlaveEntrada = false;
    public static bool LlaveExtintor = false;
    public static bool Extintor = false;
    public static bool Pistola = false;
    public static bool Linterna = false;
    public static bool Leyendo = false;
    public static bool FaseFinal = false;
    public bool LlaveInterna1;
    public bool LlaveInterna2;
    public bool LlaveInterna3;
    public bool ExtintorInterno;
    public bool PistolaInterna;
    public bool LinternaInterna;
    public bool LeyendoInterno;
    public bool FaseFinalInterno;

    void Update()
    {
        LlaveInterna1 = LlaveJardin;

        LlaveInterna2 = LlaveEntrada;

        LlaveInterna3 = LlaveExtintor;

        ExtintorInterno = Extintor;

        PistolaInterna = Pistola;

        LinternaInterna = Linterna;

        LeyendoInterno = Leyendo;

        FaseFinalInterno = FaseFinal;

    }
}
