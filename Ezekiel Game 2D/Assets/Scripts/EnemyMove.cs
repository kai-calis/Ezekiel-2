using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour{
    public int EnemySpeed;
    public int XMoveDirection;


    // Update is called once per frame
    void Update(){
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
        if (hit.distance< 1.1f){
            Flip();
            if (hit.collider.tag == "Player")
            {
                Die();

            }


        }

    }

    

    void Flip(){
        if (XMoveDirection > 0){
            XMoveDirection = -1;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

        } else{
            XMoveDirection = 1;

            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

        }


    }
    ///delete this bit if the die setting in void update doesn't work
    void Die()
    {
        SceneManager.LoadScene("dungeonscene");

    }
}

