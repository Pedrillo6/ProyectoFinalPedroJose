using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaMunicion : MonoBehaviour
{
    public LogicaArma logica;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Esto es nuevo, si no furula va fuera

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jugador")
        {

            logica = FindObjectOfType<LogicaArma>();
            logica.balasRestantes += 10;
            Destroy(gameObject);
        }
    }


}
