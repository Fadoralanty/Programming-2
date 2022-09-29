using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProyectileShooter : MonoBehaviour
{
    public GameObject proyectileprefab; //asignamos un gameobject a la variable proyectileprefab
    public Transform shootPoint;
    public ShootTypes shootType;
    public float recoil=0;
    public int ammo;
    private Animator animatorcontroller;
    private new Rigidbody2D rigidbody;
    public Action<int> onAmmoChange;
    public AudioClip shotgunSound;
    public AudioClip pistolSound;
    public AudioClip ak47Sound;
    public enum ShootTypes 
    {
        Pistol,
        Shotgun,
        AK47
    }
    public void Awake()
    {
        animatorcontroller = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        onAmmoChange?.Invoke(ammo);
    }
    public void Shoot()//metodo que se llama cuando se dispara una bala
    {
        if (ammo > 0)
        {
            float auxrecoil = recoil;
            switch (shootType)
            {
                case ShootTypes.Pistol:
                    Pistol();
                    break;
                case ShootTypes.Shotgun:
                    Shotgun();
                    break;
                case ShootTypes.AK47:
                    AK47();
                    break;
            }
            rigidbody.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
            recoil = auxrecoil;
            cameraShake.Instance.ShakeCamera(3.5f, 0.2f);
            onAmmoChange?.Invoke(ammo);
        }
    }
    public void ChangeWeapon(ShootTypes newWeapon)
    {
        shootType = newWeapon;
    }
    public void Pistol()
    {
        AudioSource.PlayClipAtPoint(pistolSound, transform.position);
        animatorcontroller.speed = 0.5f;
        GameObject bullet = Instantiate(proyectileprefab);//instanciamos en una variable de metodo el proyectileprefab
        bullet.transform.position = shootPoint.position;//le assignamos la posicion del game object de este componente
        bullet.transform.rotation = shootPoint.rotation;
        ammo--;
    }
    public void Shotgun()
    {
        AudioSource.PlayClipAtPoint(shotgunSound, transform.position);
        animatorcontroller.speed = 0.5f;
        recoil = recoil * 3;
        GameObject bullet = Instantiate(proyectileprefab);//instanciamos en una variable de metodo el proyectileprefab
        bullet.transform.position = shootPoint.position;//le assignamos la posicion del game object de este componente
        bullet.transform.rotation = shootPoint.rotation;
        GameObject bullet2 = Instantiate(proyectileprefab);//instanciamos en una variable de metodo el proyectileprefab
        bullet2.transform.position = shootPoint.position;//le assignamos la posicion del game object de este componente
        bullet2.transform.rotation = shootPoint.rotation * Quaternion.Euler(0 , 0, 25);
        GameObject bullet3 = Instantiate(proyectileprefab);//instanciamos en una variable de metodo el proyectileprefab
        bullet3.transform.position = shootPoint.position;//le assignamos la posicion del game object de este componente
        bullet3.transform.rotation = shootPoint.rotation * Quaternion.Euler(0, 0, -25);
        ammo -= 3;
    }
    public void AK47()
    {
        AudioSource.PlayClipAtPoint(ak47Sound, transform.position);
        recoil = recoil * 2;
        animatorcontroller.speed = 1;
        GameObject bullet = Instantiate(proyectileprefab);//instanciamos en una variable de metodo el proyectileprefab
        bullet.transform.position = shootPoint.position;//le assignamos la posicion del game object de este componente
        bullet.transform.rotation = shootPoint.rotation;
        ammo--;
    }
    public void getAmmo(int num)
    {
        ammo += num;
        onAmmoChange?.Invoke(ammo);
    }
}
