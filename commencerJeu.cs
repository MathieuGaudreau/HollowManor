using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commencerJeu : MonoBehaviour
{
    //perso choisi 1
    public GameObject Victor;

    //perso choisi 2
    public GameObject Victoria;

    // si victor est choisi il sera mis actif et si victoria a été choisie elle sera mise active
    void Start()
    {
        if (persoChoisi.Victor == true)
        {
            Victor.SetActive(true);
        }

        else if(persoChoisi.Victoria == true)
        {
            Victoria.SetActive(true);
        }

        Cursor.visible = false;
    }
}
