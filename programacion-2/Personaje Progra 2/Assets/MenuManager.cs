using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject skillMenu;
    private bool isMenuOpen = false;

    public void OpenSkillMenu()
    {
        if (isMenuOpen == false)
        {
            Time.timeScale = 0f;
            isMenuOpen = true;
            skillMenu.SetActive(true);
        }
        else
        {
            CloseSkillMenu();
        }
    }
    public void CloseSkillMenu()
    {
        Time.timeScale = 1f;
        isMenuOpen = false;
        skillMenu.SetActive(false);
    }
}
