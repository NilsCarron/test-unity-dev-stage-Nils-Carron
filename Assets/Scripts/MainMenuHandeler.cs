using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandeler : MonoBehaviour
{
    
    [SerializeField] private List<WeaponData> _listOfWeaponsToDisplay;

    [SerializeField]
    private GameObject _carousel;
    [SerializeField]

    private GameObject _mainMenu;

    /// <summary>
    /// Goes back to the main menu and disable the carousel
    /// </summary>
    public void OnClickReturn()
    {
        _carousel.SetActive(false);
        _mainMenu.SetActive(true);

    }
    /// <summary>
    /// Opens the carousel and disable the main menu
    /// </summary>
    public void OnClickStart()
    {
        _mainMenu.SetActive(false);
        _carousel.SetActive(true);
    }

    
}
