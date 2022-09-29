using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Image pistolIcon;
    public Image shotgunIcon;
    public Image ak47Icon;
    public ProyectileShooter playerWeapon;
    public Image uiImage;
    private Queue queue = new Queue();
    private void Awake()
    {
        uiImage.sprite = pistolIcon.sprite;
        queue.Enqueue(ProyectileShooter.ShootTypes.Pistol);
        queue.Enqueue(ProyectileShooter.ShootTypes.Shotgun);
        queue.Enqueue(ProyectileShooter.ShootTypes.AK47);
        playerWeapon.ChangeWeapon(ProyectileShooter.ShootTypes.Pistol);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToPistol();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToShotgun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToAK47();
        }
        //COLA
        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            queue.Enqueue(queue.Peek());
            queue.Dequeue();
            switch (queue.Peek())
            {
                case ProyectileShooter.ShootTypes.Pistol:
                    ChangeToPistol();
                    break;
                case ProyectileShooter.ShootTypes.Shotgun:
                    ChangeToShotgun();
                    break;
                case ProyectileShooter.ShootTypes.AK47:
                    ChangeToAK47();
                    break;
            }
        } 
    }

    public void ChangeToPistol()
    {
        playerWeapon.ChangeWeapon(ProyectileShooter.ShootTypes.Pistol);
        uiImage.sprite = pistolIcon.sprite;
    }

    public void ChangeToShotgun()
    {
        playerWeapon.ChangeWeapon(ProyectileShooter.ShootTypes.Shotgun);
        uiImage.sprite = shotgunIcon.sprite;
    }

    public void ChangeToAK47()
    {
        playerWeapon.ChangeWeapon(ProyectileShooter.ShootTypes.AK47);
        uiImage.sprite = ak47Icon.sprite;
    }
}
