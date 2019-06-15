using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakblock : MonoBehaviour
{
    //void Update(){
    // if ()
    //      Destroy(hit.collider.gameObject);
    //   }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }


}

