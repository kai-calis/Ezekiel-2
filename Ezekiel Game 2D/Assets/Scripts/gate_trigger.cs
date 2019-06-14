using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_trigger : MonoBehaviour
{

    [SerializeField]
    GameObject gate;

    private void OnTriggerEnter2D(Collider2D col)
    {
       gate.transform.position += new Vector3 (0, 4, 0);
    }

}

