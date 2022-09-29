using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//https://www.youtube.com/watch?v=9rZkiEyS66I&list=PLCFFG-BQwt311RcBeRnOmpgyI8KbuAn5F&index=1&ab_channel=BarthaSzabolcs-GameDevJourney
public class LifeController : MonoBehaviour
{
    public float currentlife;
    public float maxlife = 100;
    public UnityEvent onDie = new UnityEvent();
    public Action<float> onLifeChange;//HP y barra de vida
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    public void Awake()
    {
        ResetValues();
    }

    public void GetDamage(float damage)
    {
        if (currentlife > 0)
        {
            //animatorcontroller.SetTrigger("GetHurt");//reproduce la animacion de sufrir daño
            //CameraShake.Instance.ShakeCamera(1f, 0.5f);
            currentlife -= damage;
            Flash();
        }
        onLifeChange?.Invoke(currentlife);
        if (currentlife <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        onDie.Invoke();
    }
    public void GetHealing(float healnum)
    {

        if (currentlife == maxlife)
        {
            return;
        }
        currentlife += healnum;
        if (currentlife > maxlife)
        {
            currentlife = maxlife;

        }
        onLifeChange?.Invoke(currentlife);
    }
    public void ResetValues()//funcion que para cuando respawnee tenga toda la vida y otros stats
    {
        currentlife = maxlife;
        onLifeChange?.Invoke(currentlife);
    }
    public float GetLifePercentage()
    {
        return (float)currentlife / maxlife;
    }
    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;

    }
}
