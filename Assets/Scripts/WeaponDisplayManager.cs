using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplayManager : MonoBehaviour
{

private int _actualIndex;

    //Loading the texts we'll change depending of the weapon we want to display
    [SerializeField] private  TextMeshProUGUI _name,_price,_tier,_type,_weight,_damage,_penetration,_speed,_state;
    //Loading the image we'll update
    [SerializeField] private Image _imageToDisplay;

    void Start()
    {
        if (DatabaseManager.Instance.WeaponData.Count >= 0)
        {
            LoadWeapon(DatabaseManager.Instance.WeaponData[0]);
            _actualIndex = 0;
        }
    }

    public void LoadWeapon(WeaponData weaponToDisplay)
    {
        //Loading all the texts we just want to display, we'll use functions for harder displays
        //such as colors changing depending of an enum
        _name.text = weaponToDisplay.WeaponName;
        _price.text = weaponToDisplay.Price.ToString();
        _tier.text = weaponToDisplay.Tier + "-" + weaponToDisplay.Rarity;
        
        _type.text = "Arme de " + weaponToDisplay.Reach + " " + weaponToDisplay.Type;
        
        _weight.text = weaponToDisplay.Weight.ToString();
        _damage.text = weaponToDisplay.Damages.ToString();
        _penetration.text = weaponToDisplay.Penetration.ToString();
        _speed.text = weaponToDisplay.Speed.ToString();
        _state.text = weaponToDisplay.State.ToString();
        
        _imageToDisplay.sprite  = weaponToDisplay.Image;

    }

    public void NextWeapon()
    {
        _actualIndex += 1;
        if (_actualIndex >= DatabaseManager.Instance.WeaponData.Count)
        {
            _actualIndex = 0;
        }

        LoadWeapon(DatabaseManager.Instance.WeaponData[_actualIndex]);
    }
    
    public void PreviousWeapon()
    {
        _actualIndex -= 1;
        if (_actualIndex < 0)
        {
            _actualIndex = DatabaseManager.Instance.WeaponData.Count-1;
        }

        LoadWeapon(DatabaseManager.Instance.WeaponData[_actualIndex]);
    }

    
  
  
}
