using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persoChoisi : MonoBehaviour
{
    //variables qui détermine quel personnage à été choisi
    public static bool Victor = true;
    public static bool Victoria = false;

    //ne détruit pas cet objet en changeant de scene
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //ĉhange la scene pour la scene de jeu
    public void jouer()
    {
        SceneManager.LoadScene(3);
    }
}
