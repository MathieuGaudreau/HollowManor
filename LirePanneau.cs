using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LirePanneau : MonoBehaviour
{
    // texte qui apparait quand le perso peut lire le panneau
    public GameObject lireText;
    // Message affiché
    public GameObject panneauText;

    // Si le perso peut lire le panneau
    private bool lectureAllowed;

    // Cache le texte au début
    void Start()
    {
        lireText.gameObject.SetActive(false);
    }

    // Si le perso peut lire le panneau et appui sur E, on appel la fonction permettant de lire 
    void Update()
    {
        if(lectureAllowed && Input.GetKeyDown(KeyCode.E))
        {
            afficherText();
        } 
    }

    // Si le perso entre dans le collider, alors la lecture est permise
    private void OnTriggerEnter(Collider autreObject)
    {
        if(autreObject.gameObject.tag == "persoChoisi")
        {
            lireText.gameObject.SetActive(true);
            lectureAllowed = true;
        }
    }

    // Si le perso sort du le collider, alors il ne peut plus lire et le texte disparait
    private void OnTriggerExit(Collider autreObject)
    {
        if (autreObject.gameObject.tag == "persoChoisi")
        {
            lireText.gameObject.SetActive(false);
            lectureAllowed = false;
             panneauText.SetActive(false);
        }
    }

    // Affiche le texte du panneau correspondant
    private void afficherText()
    {
        panneauText.SetActive(true);
        if(gameObject.tag == "directionVillage"){
            panneauText.GetComponent<Text>().text = "' V i l l a g e '";
        }
        if(gameObject.tag == "directionEglise"){
            panneauText.GetComponent<Text>().text = "' É g l i s e '";
        }
    }
}
