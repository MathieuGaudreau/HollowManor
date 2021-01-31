using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choixPersonnageScript : MonoBehaviour
{
    //creer une liste avec les choix de perso dedans
    private List<GameObject> models;

    //numero du perso choisi
    private int selectionIndex = 0;
    
    //met le personnage choisi actif dans la scène et mes les autres inactifs
    private void Start()
    {
        models = new List<GameObject>();

        foreach(Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[selectionIndex].SetActive(true);
    }
// return la valeur de la position des perso dans la liste et rend actif celui choisi selon sa position
    public void choisir(int index)
    {
        if(index == selectionIndex)
        {
            return;
        }
        if(index < 0 || index >= models.Count)
        {
            return;
        }

        if(index == 0)
        {
            persoChoisi.Victor = true;
            persoChoisi.Victoria = false;
        }
        else if(index == 1)
        {
            persoChoisi.Victoria = true;
            persoChoisi.Victor = false;
        }

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
    }
}
