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

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickReturn()
    {
        _carousel.SetActive(false);
        _mainMenu.SetActive(true);

    }
    public void OnClickStart()
    {
        _mainMenu.SetActive(false);
        _carousel.SetActive(true);
    }

    
}
