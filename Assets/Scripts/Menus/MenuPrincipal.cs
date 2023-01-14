using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
 
 public GameObject Difuminado;
 public GameObject Cargando;
 public AudioSource ClicBoton;
 public AudioSource BS;
 public GameObject MenuOpciones;

 //--Variables Opciones--
[Header("Sonido")]
 [SerializeField] private TMP_Text valorVolumen;
 [SerializeField] private Slider BarraVolumen;
 [SerializeField] private float defaultVolumen = 0.5f;

 [Header("Gameplay")]
 [SerializeField] private TMP_Text ValorSensi;
 [SerializeField] private Slider BarraSensi;
 [SerializeField] private int defaultSensi = 5;
 public int mainControllerSensi = 5;
 [SerializeField] private Toggle InvertirY;

 [Header("Graficos")]
 [SerializeField] private Slider BarraBrillo;
 [SerializeField] private TMP_Text ValorBrillo;
 [SerializeField] private float defaultBrillo = 1;
 [SerializeField] private TMP_Dropdown listaCalidad;
 [SerializeField] private Toggle botonPantalla;

 private int Calidad;
 private bool PantallaCompleta = true;
 private float nivelBrillo;

 public TMP_Dropdown TipoResolucion;
 private Resolution[] resoluciones;

 [Header("Confirmacion")]
 [SerializeField] private GameObject MensajeConfirmacion;

public void Start(){
  //Para evitar que al volver del juego en pausa siga el tiempo congelado y el audio apagado
  if(Time.timeScale == 0){
    Time.timeScale = 1;
  }
  if(AudioListener.pause == true){
    AudioListener.pause = false;
  }
  //--------------------------------
  BS.Play();
  Cursor.visible = true;
  Cursor.lockState = CursorLockMode.None;
  resoluciones = Screen.resolutions;
  TipoResolucion.ClearOptions();

  List<string> options = new List<string>();

  int resolucionActual = 0;

  for(int i = 0; i < resoluciones.Length; i++){
    string option = resoluciones[i].width + " x " + resoluciones[i].height;
    options.Add(option);

    if(resoluciones[i].width == Screen.width && resoluciones[i].height == Screen.height){
       resolucionActual = i;
    }
  }
  TipoResolucion.AddOptions(options);
  TipoResolucion.value = resolucionActual;
  TipoResolucion.RefreshShownValue();   
}

 public void NewGameBotton(){
    StartCoroutine(NewGameStart());
 }

 public void OpcionSonido(float volume){
   AudioListener.volume = volume;
   valorVolumen.text = volume.ToString("0.0");
 }

 public void AplicarVolumen(){
   PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
   StartCoroutine(PopConfirmacion());
 }

 public void OpcionSensi(float sensitivity){
   mainControllerSensi = Mathf.RoundToInt(sensitivity);
   ValorSensi.text = sensitivity.ToString("0");
 }

 public void AplicarGamePlay(){
   if(InvertirY.isOn){
      PlayerPrefs.SetInt("masterInvertY", 1);   //Invierte Y
   } else{
      PlayerPrefs.SetInt("masterInvertY", 0);   //NO Invierte Y
   }

   PlayerPrefs.SetFloat("masterSen", mainControllerSensi);
   StartCoroutine(PopConfirmacion());
 }

 public void OpcionBrillo(float brightness){
   nivelBrillo = brightness;
   ValorBrillo.text = brightness.ToString("0.0");
 }

 public void OpcionPantallaCompleta(bool isFullscreen){
   PantallaCompleta = isFullscreen;
 }

 public void OpcionCalidad(int qualityIndex){
   Calidad = qualityIndex;
 }

 public void OpcionResolucion(int resolutionIndex){
   Resolution resolucion = resoluciones[resolutionIndex];
   Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
 }

 public void AplicarGraficos(){
   PlayerPrefs.SetFloat("masterBrightness", nivelBrillo);

   PlayerPrefs.SetInt("masterQuality", Calidad);
   QualitySettings.SetQualityLevel(Calidad);

   PlayerPrefs.SetInt("masterFullscreen", (PantallaCompleta ? 1 : 0));
   Screen.fullScreen = PantallaCompleta;

   StartCoroutine(PopConfirmacion());
 }

 public void DefaultButton(string MenuType){
   if(MenuType == "Audio"){
      AudioListener.volume = defaultVolumen;
      BarraVolumen.value = defaultVolumen;
      valorVolumen.text = defaultVolumen.ToString("0.0");
      AplicarVolumen();
   }

   if(MenuType == "GamePlay"){
      ValorSensi.text = defaultSensi.ToString("0");
      BarraSensi.value = defaultSensi;
      mainControllerSensi = defaultSensi;
      InvertirY.isOn = false;
      AplicarGamePlay();
   }

   if(MenuType == "Grafico"){
      BarraBrillo.value = defaultBrillo;
      ValorBrillo.text = defaultBrillo.ToString("0.0");

      listaCalidad.value = 1;
      QualitySettings.SetQualityLevel(1);

      botonPantalla.isOn = false;
      Screen.fullScreen = false;

      Resolution currentResolution = Screen.currentResolution;
      Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
      TipoResolucion.value = resoluciones.Length;
      AplicarGraficos();
   }
 }

 public void Creditos(){
    StartCoroutine(EscenaCreditos());
 }

 public void Salir(){
    StartCoroutine(CerrarApp());
 }

 IEnumerator NewGameStart(){
   MenuOpciones.SetActive(false);
   Difuminado.SetActive(true);
   ClicBoton.Play();
   yield return new WaitForSeconds(1.5f);
   Cargando.SetActive(true);
   yield return new WaitForSeconds(0.5f);
   SceneManager.LoadScene(2);

 }

 IEnumerator PopConfirmacion(){
   MensajeConfirmacion.SetActive(true);
   yield return new WaitForSeconds(1.5f);
   MensajeConfirmacion.SetActive(false);
 }

 IEnumerator EscenaCreditos(){
   MenuOpciones.SetActive(false);
   Difuminado.SetActive(true);
   ClicBoton.Play();
   yield return new WaitForSeconds(1.5f);
   Cargando.SetActive(true);
   yield return new WaitForSeconds(0.5f);
   SceneManager.LoadScene(4);
 }

 IEnumerator CerrarApp(){
   MenuOpciones.SetActive(false);
   Difuminado.SetActive(true);
   ClicBoton.Play();
   //Debug utilizado para no tener que compilar el codigo para comporbar que el boto quit funciona
   Debug.Log("Quit");
   yield return new WaitForSeconds(1.5f);
   Application.Quit();
 }
}
