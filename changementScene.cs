using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changementScene : MonoBehaviour
{
    //image pour le curseur
    public Texture2D cursorTexture;

    //changer la grandeur du curseur
    public CursorMode cursorMode = CursorMode.ForceSoftware;

    //positionner le curseur
    public Vector2 hotSpot = Vector2.zero;


    // instancie le curseur
    void Start()
    {
         Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    //permet d'acceder a la scene de changement de perso
    public void ChangerScene()
    {
        SceneManager.LoadScene(1);
    }


    //permet d'acceder a la scene d'instruction
    public void AllerInstrcution()
    {
        SceneManager.LoadScene(2);
    }


    //permet de retourner au menu
    public void RetourMenu()
    {
        SceneManager.LoadScene(0);
    }
}
