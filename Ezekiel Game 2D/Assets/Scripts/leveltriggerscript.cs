using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltriggerscript : MonoBehaviour
{
    [SerializeField] private string Loadlevel;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            SceneManager.LoadScene(Loadlevel);
            
        }

    }
}