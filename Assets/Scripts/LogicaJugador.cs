using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    [SerializeField] private Animator animadorPerder;
    public Puntuacion puntuacion;
    public AudioClip musicaAmbiente;
    public AudioClip musicaMunicion;
    public AudioClip musicaVida;

    // Use this for initialization
    void Start()
    {
        vida = GetComponent<Vida>();
        puntuacion.valor = 0;
        gameObject.GetComponent<AudioSource>().PlayOneShot(musicaAmbiente, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if (Vida0) return;
        if (vida.valor <= 0)
        {
            AudioListener.volume = 0f;
            animadorPerder.SetTrigger("Mostrar");
            Vida0 = true;
            Invoke("ReiniciarJuego", 2f);
        }
    }

    void ReiniciarJuego()
    {
        PlayerPrefs.SetFloat("puntuacion", puntuacion.valor);
        SceneManager.LoadScene("EscenaFinal");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        puntuacion.valor = 0;
        AudioListener.volume = 1f;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemigo")
        {
            //gameObject.GetComponent<AudioSource>().volume = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            //gameObject.GetComponent<AudioSource>().volume = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "municion")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(musicaMunicion, 0.5f);
        }
        if (other.gameObject.tag == "botiquin")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(musicaVida, 0.5f);
        }
    }


}