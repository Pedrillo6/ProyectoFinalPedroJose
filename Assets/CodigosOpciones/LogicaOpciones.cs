using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaOpciones : MonoBehaviour
{

    public ControladorOpciones panelOpciones;
    public bool ratonActivo = false;

    /*public Button botonMenu;
    public Button botonAtras;*/
    

    // Start is called before the first frame update
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ratonActivo)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            MostrarOpciones();
            /*botonMenu = FindObjectOfType<BotonMenu>();
            botonMenu.SetActive(false);
            botonAtras = FindObjectOfType<BotonAtras>();
            botonAtras.SetActive(true);*/
        }


        if (!ratonActivo)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            panelOpciones.pantallaOpciones.SetActive(false);
            ratonActivo = false;
        }
    }

    public void MostrarOpciones()
    {
        ratonActivo = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panelOpciones.pantallaOpciones.SetActive(true);
        
        //GameObject.Find("Jugador").SetActive(false);

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            panelOpciones.pantallaOpciones.SetActive(false);
                GameObject.Find("Jugador").SetActive(false);
        }*/
    }

    public void pulsarBotonAtras()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panelOpciones.pantallaOpciones.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Escena2");
    }

}
