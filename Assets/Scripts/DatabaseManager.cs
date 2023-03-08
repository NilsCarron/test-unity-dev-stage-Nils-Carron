using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    //Changing the Weapon for a list of weapon, to display mutliple of them
    //The Level Designers have to fill this list depending of wich weapons they wants the player to have acces
    [SerializeField] private List<WeaponData> _weaponData;
    
    private static DatabaseManager _instance = null;
    public static DatabaseManager Instance => _instance;

    public List<WeaponData> WeaponData => _weaponData;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
