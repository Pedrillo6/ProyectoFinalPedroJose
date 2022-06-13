using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaVol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volumenAudio", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
