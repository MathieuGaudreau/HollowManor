using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musiqueIntroScript : MonoBehaviour
{
    // ne détruit pas la musique d'into si on chamge de scène
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // détruit la musique d'intro quand la scène de jeu apparait
    void Update()
    {
        if( SceneManager.GetActiveScene().name == "scene_jeu")
        {
            Destroy(gameObject);
        }
    }
}
