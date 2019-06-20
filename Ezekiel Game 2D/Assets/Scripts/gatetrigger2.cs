using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatetrigger2 : MonoBehaviour
{

    [SerializeField]
    GameObject gate2;

    private void OnTriggerEnter2D(Collider2D col)
    {
        gate2.transform.position += new Vector3(0, 4, 0);
    }

    //public Collider2D Player;
    //public Collider2D gate2;


    // private void OnTriggerEnter2D(Collider2D collider)
    //{
    //   if (collider.gate2 && GameObject.Player = true)
    // {

    //    gate2.transform.position += new Vector3(0, 4, 0);
    //}
    // }



}
