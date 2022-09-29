using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip confirm;
    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(confirm, transform.position);
    }
}
