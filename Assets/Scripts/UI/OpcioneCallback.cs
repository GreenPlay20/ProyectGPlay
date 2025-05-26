using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpcioneCallback : MonoBehaviour
{
    [SerializeField] private GameObject Interfaz;
    [SerializeField] private GameObject Opciones;
    [SerializeField] private Button Continuar;
    [SerializeField] private Button Reiniciar;
    [SerializeField] private Button Salir;
    [SerializeField] private Button BtnOpciones;
    // Start is called before the first frame update
    private void Awake()
    {
        Interfaz.SetActive(true);
        Opciones.SetActive(false);
        Continuar.onClick.AddListener(() =>
        {
            MenuOpciones.SiPausar();
            Interfaz.SetActive(true);
            Opciones.SetActive(false);
        });
        Salir.onClick.AddListener(() =>
        {
            MenuOpciones.SalirInicio();
        });
        BtnOpciones.onClick.AddListener(() =>
        {
            MenuOpciones.SiPausar();
            Interfaz.SetActive(false);
            Opciones.SetActive(true);
        });
        Reiniciar.onClick.AddListener(() =>
        {
            MenuOpciones.Recargar();
            Interfaz.SetActive(true);
            Opciones.SetActive(false);
        });
    }
   
    
    
}
