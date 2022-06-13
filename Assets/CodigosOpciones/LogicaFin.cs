using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LogicaFin : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text puntuacion;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        puntuacion.text = "Puntuacion -> " + PlayerPrefs.GetFloat("puntuacion", 0);

    }


    public void Nivel1()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
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
