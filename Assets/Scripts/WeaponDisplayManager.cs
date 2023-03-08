using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplayManager : MonoBehaviour
{


    public WeaponData WeaponToDisplay;

    //Loading the texts we'll change depending of the weapon we want to display
    [SerializeField] private  TextMeshProUGUI _name,_price,_tier,_type,_weight,_damage,_penetration,_speed,_state;
    //Loading the image we'll update
    [SerializeField] private Image _imageToDisplay;

    void Start()
    {
        //Loading all the texts we just want to display, we'll use functions for harder displays
        //such as colors changing depending of an enum
        _name.text = WeaponToDisplay.WeaponName;
        _price.text = WeaponToDisplay.Price.ToString();
        _tier.text = WeaponToDisplay.Tier + "-" + WeaponToDisplay.Rarity;
        
        _type.text = "Arme de " + WeaponToDisplay.Reach + " " + WeaponToDisplay.Type;
        
        _weight.text = WeaponToDisplay.Weight.ToString();
        _damage.text = WeaponToDisplay.Damages.ToString();
        _penetration.text = WeaponToDisplay.Penetration.ToString();
        _speed.text = WeaponToDisplay.Speed.ToString();
        _state.text = WeaponToDisplay.State.ToString();
        
        _imageToDisplay.sprite  = WeaponToDisplay.Image; 
    }
    
  
  
}
