using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiScript : MonoBehaviour
{
    //acceder au AI de l'ennemi
    UnityEngine.AI.NavMeshAgent navAI;

    //temps que l'ennemi va avancer dans une direction avant de changer
    public float wanderTime;
    
    //vitesse de marche 
    public float vitesseMouvement = 0.05f;

    //acceder aux animations
    Animator ennemiAnim;


    //acceder au ai, au animator et met la ai false pour que l'ennemi wander
    void Start()
    {
        navAI = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAI.enabled = false;
        ennemiAnim = GetComponent<Animator>();
    }

    //si le perso est dans un rayon de l'ennemi, le ai active et l'ennemi commence a suivre le perso
    //sinon, l'ennemi va se promener dans la map
    void Update()
    {

        if (!personnageScript.persoMort)
        {
            //va suivre le personnage si il vien dans le rayon choisi
            if (Vector3.Distance(GameObject.FindWithTag("persoChoisi").transform.position, transform.position) < 40)
            {
                navAI.enabled = true;

                if (navAI.enabled == true)
                {
                    navAI.SetDestination(GameObject.FindWithTag("persoChoisi").transform.position);
                }
            }

            //sinon il va marcher dans la map avec une trajectoire aléatoire
            else
            {
                navAI.enabled = false;

                if (wanderTime > 0)
                {
                    transform.Translate(Vector3.forward * vitesseMouvement);
                    wanderTime -= Time.deltaTime;
                }

                else
                {
                    wanderTime = Random.Range(5f, 20f);
                    Wander();
                }
            }
        }
        else
        {
            wanderTime = 0;
            navAI.enabled = false;
        }
    }
    
    //fait marcher l'ennemi dans la map 
    void Wander()
    {
        transform.eulerAngles = new Vector3 (0,Random.Range (0,360), 0);
    }

    //si l'ennemi entre en collision avec le perso, il le frappe et ce met en idle et s'immobilise
    //active la mort du personnage
    private void OnCollisionEnter(Collision autreObject)
    {
        if(autreObject.gameObject.tag == "persoChoisi")
        {
            personnageScript.persoMort = true;
            ennemiAnim.SetBool("persoMort", true);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
