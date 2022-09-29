using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBox : MonoBehaviour
{
    public AudioClip ammoSound;
    [SerializeField] private int ammoInBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(ammoSound, transform.position);
            ProyectileShooter player = collision.GetComponent<ProyectileShooter>();
            player.getAmmo(ammoInBox);
            Destroy(gameObject);
        }
    }
}
