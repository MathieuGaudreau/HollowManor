using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class personnageScript : MonoBehaviour
{

    //rigidbody du personnage 
    public Rigidbody rigidbodyPerso;

    //caméra qui suit le personnage
    public GameObject camera;

    //acceder au animation du perso
    Animator persoAnim;

    //vitesse de déplacement du personnage
    public  float vitesseDeplacement = 3f; 

    //pour savoir si le perso cours
    public bool isRunning = false;

    //nombre de clé trouvée
    public static int nbKey = 0;

    //nombre d'indices trouvés
    public static int nbIndice = 0;

    //texte du ui pour afficher le nombre de clé et d'indices
    public GameObject texteKey;

    public GameObject texteIndice;

    //savoir si le perso est mort ou non
    public static bool persoMort = false;

    // acceder au animator et rigidbody du perso
    void Start()
    {
        rigidbodyPerso = GetComponent<Rigidbody>();

        persoAnim = GetComponent<Animator>();
    }

    // si le perso n'est pas mort, il peut ce déplacer, sauter et courrir
    // vérifie si le perso a trouver un indices ou une clé
    void Update()
    {
        if (!persoMort)
        {
            if(!GestionnaireCam.camIndice)
            {

            // permet de sauter si le perso touche au sol
            persoAnim.SetFloat("vitesseDep", rigidbodyPerso.velocity.magnitude);

            RaycastHit infoCollision;

            bool auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.2f, -Vector3.up, out infoCollision, 0.8f);

            persoAnim.SetBool("jump", !auSol);

            if (Input.GetKeyDown(KeyCode.Space) && auSol)
            {
                rigidbodyPerso.velocity += new Vector3(0, 5, 0);
            }

            //Déplacer le perso selon la caméra si la cam TPS est activer
            if(GestionnaireCam.TPS == true)
            {
                //permet au perso de ce déplacer
                DeplaceDirectionCamera();
            }

            if(GestionnaireCam.FPS == true)
            {
                //permet au perso de ce déplacer
                DeplacementVelocity();
            }

            //si la touche shift est appuyé le perso va plus vite et son animation de course est activée
            if (Input.GetKey(KeyCode.LeftShift))
            {

                isRunning = true;
                vitesseDeplacement = 6;
                persoAnim.SetBool("isRunning", true);
            }

            else
            {
                isRunning = false;
                vitesseDeplacement = 3;
                persoAnim.SetBool("isRunning", false);
            }
        }
        }

        //si le perso est mort, son animation de mort est activée et la scène de choix de perso est appelée
        else
        {
            persoAnim.SetTrigger("persoMort");

            Invoke("finJeu", 4);
        }

            //vérifie si le nombre de clé et d'indice change et l'affiche
             texteKey.GetComponent<Text>().text = nbKey.ToString() + " / 2";
             texteIndice.GetComponent<Text>().text = nbIndice.ToString() + " / 4";
    }

    //permet au personnage de ce déplacer selon les angles de la caméra
    void DeplaceDirectionCamera()
    {

        float hDeplacement = Input.GetAxis("Horizontal");
        float vDeplacement = Input.GetAxis("Vertical");

        //la direction du perso suit les angles de la caméra
        Vector3 directionDep = camera.transform.forward * vDeplacement + camera.transform.right * hDeplacement;

        directionDep.y = 0; 

        if (directionDep != Vector3.zero)
        {
        transform.forward = directionDep;
        
        rigidbodyPerso.velocity = (transform.forward * vitesseDeplacement) + new Vector3(0, rigidbodyPerso.velocity.y, 0);
        }
    }

    //permet au perso de se déplacer à l'aide des forces
    void  DeplacementVelocity()
    {
        // forces
       var vDeplacement = Input.GetAxis("Vertical") * vitesseDeplacement;
       var tourne = Input.GetAxis("Mouse X") * vitesseDeplacement;

       rigidbodyPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0, rigidbodyPerso.velocity.y, 0);

       transform.Rotate(0, tourne , 0);
    }

    //remet le curseur visible, change la scène et enlève la mort du perso
    void finJeu()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = true;
        persoMort = false;
    }
}
