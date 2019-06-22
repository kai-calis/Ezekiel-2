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

   


}
