using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private Button Jugar;
    [SerializeField] private Button Salir;

    private void Awake()
    {
        Jugar.onClick.AddListener(() =>
        {
            //codigo al hacer click en jugar
            LoadScene.Cargar(LoadScene.Scene.Nivel1_Escenario);
        }
        );
        Salir.onClick.AddListener(() =>
        {
            //codigo al hacer click en salir
            Application.Quit();
            Debug.Log("se salio");
        }
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
