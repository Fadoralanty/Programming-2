using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPItem : MonoBehaviour
{
    public AudioClip powerUpSound;
    public GameObject powerUpUIPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PowerupStack.instance.AddElement(powerUpUIPrefab);
            AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
            Destroy(gameObject);
        }
    }
}
