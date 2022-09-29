using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacterController : MonoBehaviour
{
    public float damage=0;
    public float speed = 0;
    public GameController gC;
    public RankingManager rManager;
    [SerializeField] private float jumpForceSpeed = 0;
    [SerializeField] private float groundDetectionDistance = 1f;
    [SerializeField] private LayerMask groundDetectionLayers; //layers de colision con las que el player detecta "Piso"
    private bool isGrounded = true;
    private bool isDead=false;
    public LifeController lifeController;
    private Animator animatorcontroller;
    private Rigidbody2D myRigidBody;

    public void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animatorcontroller = GetComponent<Animator>();
        animatorcontroller.SetBool("IsRunning", false);
        animatorcontroller.SetBool("IsDead", false);
        animatorcontroller.SetBool("IsGrounded", false);
    }
    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //----------------- INPUT DEL PLAYER ---------------------
        if (horizontal != 0)
        {
            //GetAxis is smoothed based on the “sensitivity” setting so that value gradually changes from 0 to 1, or 0 to -1. 
            //Whereas GetAxisRaw will only ever return 0, -1, or 1 exactly (assuming a digital input such as a keyboard or joystick button)
            if (isDead == false)//chequeo si esta muerto el jugador asi no se mueve mientras esta muerto
            {   // ROTACION DEL PLAYER
                if (horizontal < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    animatorcontroller.SetBool("IsRunning", true);
                }

                if (horizontal > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animatorcontroller.SetBool("IsRunning", true);
                }
            }
        }

        if (horizontal == 0)
        {
            animatorcontroller.SetBool("IsRunning", false);
        }
        // MOVIMIENTO DEL PLAYER
        float xmovement = horizontal * speed * Time.deltaTime;

        if (isDead == false)//chequeo si esta muerto el jugador asi no se mueve mientras esta muerto
        {
            transform.position += new Vector3(xmovement, 0f, 0f);
        }
        //
        //---------*SALTO DEL PLAYER*---------------
        if (Input.GetButtonDown("Jump") && isGrounded == true && !isDead)
        {
            animatorcontroller.SetTrigger("Jump");
            animatorcontroller.SetBool("IsGrounded", false);
            isGrounded = false;
            myRigidBody.velocity = Vector2.up * jumpForceSpeed; //el salto 
        }
        //--------ATAQUE DEL PLAYER ----------
        if (Input.GetButton("Fire1") && isGrounded == true && !isDead /*&& arrows > 0*/)
        {
            animatorcontroller.SetBool("IsAttacking",true );
        }
        else
        {
            animatorcontroller.SetBool("IsAttacking", false);
        }
        if (Input.GetKeyUp(KeyCode.E))  //Usar PowerUP
        {
            if (PowerupStack.instance.powerups.GetIndexCount() > 0)
            {
                PowerupStack.instance.RemoveElement();
                lifeController.GetHealing(20);
            }
        }
        //------DETECCION DEL PISO DEL PLAYER------
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, Vector2.down, groundDetectionDistance, groundDetectionLayers);//raycast para detectar que toca el piso y cambiar IsGrounded
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDetectionDistance, 0), Color.red);
        if (hit.collider != null)
        {
            isGrounded = true;
            animatorcontroller.SetBool("IsGrounded", true);
        }
        else
        {
            isGrounded = false;
            animatorcontroller.SetBool("IsGrounded", false);
        }
        //------------------- FIN DEL INPUT DEL PLAYER -------------------------------------------------
    }
    public void GameOver()//Funcion de muerte del player
    {
        gC.OpenScoreScreen();
        rManager.AddPlayerOnRanking();
        isDead = true;
        animatorcontroller.SetBool("IsDead", true);
        Destroy(gameObject, 2f);//destruimos al player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            GameOver();
        }
    }
}

