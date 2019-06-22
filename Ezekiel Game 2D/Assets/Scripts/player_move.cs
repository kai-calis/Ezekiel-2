using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added event bc of Brackeys
using UnityEngine.Events;

public class player_move : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 125;
    private float moveX;
    public bool isGrounded;
    public Animator animator;

    ////////////////////////Start of Brackeys added code:
    private Rigidbody2D m_Rigidbody2D;
    private bool m_Grounded;

    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

    //Script of Brackeys for events

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    //public BoolEvent OnCrouchEvent;
    //private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

       
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }
    ///////////////////////End of BRACKEY's script
    

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
        animator.SetFloat("speed", Mathf.Abs(moveX));


    }

    void PlayerMove()
    { //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
        //ANIMATION
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false) {
            FlipPlayer();

        }
        else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {//JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;

    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }

    //CODE FOR to know if you stopped jumping? (added bc of Brackeys)
    public void  OnLanding ()
    {
        animator.SetBool("isJumping", false);


    }


    void PlayerRaycast() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance< 2f && hit.collider.tag == "guard"){
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 150);
            hit.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;

            hit.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyMove> ().enabled = false;
            //Destroy(hit.collider.gameObject);
           
        }
        if (hit != null && hit.collider != null && hit.distance < 2f && hit.collider.tag != "guard"){
            isGrounded = true;


        }


    }

}
