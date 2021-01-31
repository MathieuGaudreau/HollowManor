using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot : MonoBehaviour
{
    //pivot de la caméra
    public GameObject camPivot;

    //position de l"objet sur la camér
    public GameObject positionRayCastCamera;

    //hauteur du pivot de la caméra
    public float hauteurPivot;

    //distance de la caméra par report du perso
    public float distanceCameraLoin = 4;

    //distance a laquelle la caméra se rapproche du perso
    public float distanceCameraPret =0.4f;

    //la caméra suit le personnage et bouge avec la souris
    //si la caméra et trop proche d'un objet elle se rapproche du personnage
    void Update()
    {
        //permet de suivre et regarder le personnage
        transform.position = GameObject.FindWithTag("persoChoisi").transform.position + new Vector3(0, hauteurPivot,0);

        transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0); 

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y, 0 );

        camPivot.transform.LookAt(transform);

        //rapproche la caméra si un object est trop proche
        if(Physics.Raycast(positionRayCastCamera.transform.position, positionRayCastCamera.transform.forward, distanceCameraLoin))
        {
            camPivot.transform.localPosition = new Vector3(0,0,distanceCameraPret);
            
        }
        else
        {
            camPivot.transform.localPosition = new Vector3(0,0,distanceCameraLoin);
        }

    }
}
