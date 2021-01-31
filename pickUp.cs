using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    //texte qui apparait quand on peut prendre un objet
    public GameObject pickUpText;

    //si le personnage peut prendre un objet
    private bool pickUpAllowed;


    //met le texte  invisible au début
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    //si on appuie sur E et que le perso peut prendre un objet, la fonction pickUp est appelée
    void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }


    //si le personnage entre dans le collider de l'objet, le perso peut le prendre et le texte apprait 
    private void OnTriggerEnter(Collider autreObject)
    {
        if(autreObject.gameObject.tag == "persoChoisi")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }


    //si le personnage sort du collider de l'objet, le texte disparait et il ne peut plus le prendre
    private void OnTriggerExit(Collider autreObject)
    {
        if (autreObject.gameObject.tag == "persoChoisi")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    // détruit l'objet, enleve le texte et augmente le nombre de clé et d'indices trouvés
    private void PickUp()
    {
        Destroy(gameObject);
        pickUpText.gameObject.SetActive(false);

        if(gameObject.tag == "key")
        {
            personnageScript.nbKey += 1;
        }

        if (gameObject.tag == "indice")
        {
            personnageScript.nbIndice += 1;
        }
    }
}
