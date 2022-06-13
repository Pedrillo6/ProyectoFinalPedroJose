using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJuego : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    public GameObject panelInicio;

    // Start is called before the first frame update
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
        panelInicio = GameObject.FindGameObjectWithTag("Inicio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarOpciones()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panelOpciones.pantallaOpciones.SetActive(true);
        panelInicio.SetActive(false);
    }

    public void pulsarBotonAtras()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panelOpciones.pantallaOpciones.SetActive(false);
    }

    public void pulsarBotonAtras2()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //panelOpciones.pantallaOpciones.SetActive(false);
        panelInicio.SetActive(true);
        panelOpciones.pantallaOpciones.SetActive(false);
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Escena2");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
