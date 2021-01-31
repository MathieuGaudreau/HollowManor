using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireCam : MonoBehaviour
{
    // référence à la cam FPS
    public GameObject camFPS;

    // référence à la cam TPS
    public GameObject camTPS;

    // référence à la cam Indice
    public GameObject camInd;

    //pour savoir l'état de la cam FPS
    public static bool FPS = false;

    //pour savoir l'état de la cam TPS
    public static bool TPS = true;

    //pour savoir l'état de la cam Indice
    public static bool camIndice = false;

    // Changement de caméra par touches clavier
    void FixedUpdate()
    {
        // Activation de la TPS
        if(Input.GetKeyDown("1"))
        {
            camFPS.transform.position =  GameObject.FindWithTag("persoChoisi").transform.position + new Vector3(0 , 2f, .3f);
            camFPS.transform.rotation =  GameObject.FindWithTag("persoChoisi").transform.rotation;
            FPS = true;
            TPS = false;
            camFPS.SetActive(true);
            camTPS.SetActive(false);
            camInd.SetActive(false);
            camFPS.transform.parent = GameObject.FindWithTag("persoChoisi").transform;
        }

        // Activation de la cam TPS
        if(Input.GetKeyDown("2"))
        {
            TPS = true;
            FPS = false;
            camTPS.SetActive(true);
            camFPS.SetActive(false);
            camInd.SetActive(false);
        }

        // Activation de la cam indice
        if(Input.GetKeyDown("3"))
        {
            TPS = false;
            FPS = false;
            camTPS.SetActive(false);
            camFPS.SetActive(false);
            camInd.SetActive(true);
            camIndice = true;
            Invoke("finIndice", 3f);
        }  
    }

    //Quand la cam Indice esst active, on laisse un délai de 3sec avant de la désactiver    
    void finIndice()
    {
        camIndice = false;
        TPS = true;
        FPS = false;
        camTPS.SetActive(true);
        camFPS.SetActive(false);
        camInd.SetActive(false);
    }
}
