using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAmmo : MonoBehaviour
{
    public GameObject municionPrefab;
    public Transform[] puntosDeGeneracion;
    public float tiempoDeGeneracion = 5f;
    // Use this for initialization
    void Start()
    {
        puntosDeGeneracion = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            puntosDeGeneracion[i] = transform.GetChild(i);

        }

        StartCoroutine(AparecerMunicion());
    }

    IEnumerator AparecerMunicion()
    {
        while (true)
        {
            for (int i = 0; i < puntosDeGeneracion.Length; i++)
            {
                Transform puntoDeGeneracion = puntosDeGeneracion[i];
                Instantiate(municionPrefab, puntoDeGeneracion.position, puntoDeGeneracion.rotation);
            }
            yield return new WaitForSeconds(tiempoDeGeneracion);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
