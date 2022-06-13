using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class web : MonoBehaviour
{
    [System.Serializable]
    public struct estructuraDatosWeb
    {
        [System.Serializable]
        public struct registro
        {
            public string nombre;
            public float puntaje;
        }
        public List<registro> registros;
    }

    public estructuraDatosWeb datos;


    public Transform tabla;
    public Transform nuevo;
    public GameObject plantillaRegistros;
    int cantidadRegistros = 5;
    public float miPuntaje;

    public TMPro.TMP_InputField miNombre;

    [ContextMenu("Leer")]

    public void Leer(System.Action accionAlTerminar)
    {
        StartCoroutine(CorrutinaLeer(accionAlTerminar));
    }

    private IEnumerator CorrutinaLeer(System.Action accionAlTerminar)
    {
        UnityWebRequest web = UnityWebRequest.Get("https://pipasjourney.com/compartido/tablaHiscores.txt");
        yield return web.SendWebRequest();
        if (!web.isNetworkError && !web.isHttpError)
        {
            datos = JsonUtility.FromJson<estructuraDatosWeb>(web.downloadHandler.text);
            accionAlTerminar();
        }
        else
        {
            Debug.LogWarning("Hay un problema al abrir el archivo");
        }
    }

    [ContextMenu("Escribir")]

    public void Escribir()
    {
        StartCoroutine(CorrutinaEscribir());
    }

    private IEnumerator CorrutinaEscribir()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "tablaHiscores.txt");
        form.AddField("texto", JsonUtility.ToJson(datos));

        UnityWebRequest web = UnityWebRequest.Post(
            "https://pipasjourney.com/compartido/escribir.php",
            form
        );
        yield return web.SendWebRequest();
        if (!web.isNetworkError && !web.isHttpError)
        {
            Debug.Log(web.downloadHandler.text);
        }
        else
        {
            Debug.LogWarning("Hay un problema al abrir el archivo");
        }
    }


    [ContextMenu("Crear Tabla")]
    void CrearTabla()
    {
        for (int i = cantidadRegistros; i > 0; i--)
        {
            GameObject inst = Instantiate(plantillaRegistros, tabla);
            inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * 50f);
        }
    }

    [ContextMenu("Pasar Datos a Tabla")]
    void PasarDatosATabla()
    {
        for (int i = 0; i < cantidadRegistros; i++)
        {
            tabla.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = datos.registros[i].nombre;
            tabla.GetChild(i).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = datos.registros[i].puntaje.ToString();
        }
    }


    [ContextMenu("Revisar Record")]
    void revisarSiHizoRecord()
    {
        if(miPuntaje > datos.registros[cantidadRegistros - 1].puntaje)
        {
            tabla.gameObject.SetActive(false);
            nuevo.gameObject.SetActive(true);
        }
        else
        {
            tabla.gameObject.SetActive(true);
            nuevo.gameObject.SetActive(false);
        }
    }

    [ContextMenu("Insertar")]
    void insertarNuevoRegistro()
    {
        for (int i = 0; i < cantidadRegistros; i++)
        {
            if(miPuntaje > datos.registros[i].puntaje)
            {
                datos.registros.Insert(i, new estructuraDatosWeb.registro()
                {
                    nombre = miNombre.text,
                    puntaje = miPuntaje
                });
                break;
            }
        }
    }

    void Start()
    {
        miPuntaje = PlayerPrefs.GetFloat("puntuacion", 0);
        Leer(crearTablaPasarDatosYRevisarRecord);
    }

    void crearTablaPasarDatosYRevisarRecord()
    {
        CrearTabla();
        PasarDatosATabla();
        revisarSiHizoRecord();
    }

    public void inputTermina()
    {
        nuevo.gameObject.SetActive(false);
        tabla.gameObject.SetActive(true);
        Leer(InsertarYEscribir);
    }

    void InsertarYEscribir()
    {
        insertarNuevoRegistro();
        Escribir();
        PasarDatosATabla();
    }

}
