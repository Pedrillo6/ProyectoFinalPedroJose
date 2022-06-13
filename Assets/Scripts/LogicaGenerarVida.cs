using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGenerarVida : MonoBehaviour
{
    public LogicaJugador logica;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Esto es nuevo, si no furula va fuera

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jugador")
        {

            logica = FindObjectOfType<LogicaJugador>();
            logica.vida.valor = 100;
            Destroy(gameObject);
        }
    }


}