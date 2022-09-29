using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private LifeController lifeController;
    public GameController gController;
    private Animator animatorcontroller;
    private Rigidbody2D myRigidBody;
    [SerializeField] private Transform player = null;
    [SerializeField] private float damage;
    [SerializeField] private float knockback = 0;
    [SerializeField] protected float speed = 5f;
    [SerializeField] private PlayerDetection detectionArea;
    [SerializeField] private PlayerDetection shootArea;

    private void Awake()
    {
        lifeController = GetComponent<LifeController>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animatorcontroller = GetComponent<Animator>();
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 dir = new Vector3(player.position.x - transform.position.x, 0, 0);
            //Vector3 dir = new Vector3(transform.position.x - player.position.x, 0, 0);//para que se aleje del jugador, invertis el orden de la resta y asi, ya se aleja el slime del player
            dir.Normalize();
            float distance = Vector3.Distance(player.position, transform.position);
            if (dir.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (detectionArea.playerDetected == true && shootArea.playerDetected==false)
            {
                transform.position += dir * speed * Time.deltaTime;
                animatorcontroller.SetBool("IsRunning", true);
                animatorcontroller.SetBool("IsShooting", false);
            }
            else
            {
                animatorcontroller.SetBool("IsRunning", false);
            }

            if (shootArea.playerDetected == true)
            {
                animatorcontroller.SetBool("IsRunning", false);
                animatorcontroller.SetBool("IsShooting", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
    public void OnDestroy()
    {
        gController.AddScoreWhenKillEnemy();
        Destroy(gameObject);
    }
}