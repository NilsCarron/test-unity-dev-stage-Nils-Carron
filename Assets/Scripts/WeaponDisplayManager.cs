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
        _price.text = weaponToDisplay.Price + " Po";
        DisplayTier(_tier, weaponToDisplay.Tier, weaponToDisplay.Rarity);
        
        _type.text = "Arme de " + weaponToDisplay.Reach + " " + weaponToDisplay.Type;
        
        _weight.text = weaponToDisplay.Weight + " Kg";
        _damage.text = weaponToDisplay.Damages.ToString();
        _penetration.text = weaponToDisplay.Penetration.ToString();
        _speed.text = weaponToDisplay.Speed.ToString();
        DisplayState(_state, weaponToDisplay.State);
        _imageToDisplay.sprite  = weaponToDisplay.Image;

    }

    private void DisplayState(TextMeshProUGUI textToModify, float state)
    {
        if (state < 1)
        {
            textToModify.text = "Cassée <color=grey>" + state.ToString() + "%</color>";
        } else if (state >= 1 && state < 15)
        {
            textToModify.text = "Fragile <color=red>" + state.ToString()+ "%</color>";
        }else if (state >= 15 && state < 49)
        {
            textToModify.text = "Très Usée <color=orange>" + state.ToString()+ "%</color>";
        }else if (state >= 49 && state < 80)
        {
            textToModify.text = "Usée <color=yellow>" + state.ToString()+ "%</color>";
        }else if (state >= 80)
        {
            textToModify.text = "Neuve <color=green>" + state.ToString()+ "%</color>";
        }
        
        
    }
    private void DisplayTier(TextMeshProUGUI textToModify, WeaponData.WeaponTier tier, WeaponData.WeaponRarity rarity)
    {
        textToModify.text = tier + " - " + rarity;
        switch (rarity)
        {
            case WeaponData.WeaponRarity.Commun :
                textToModify.color = Color.white;
                break;
            case WeaponData.WeaponRarity.Rare :
                textToModify.color = Color.blue;
                break;

            case WeaponData.WeaponRarity.Epique :
                textToModify.color = Color.magenta;
                break;

            case WeaponData.WeaponRarity.Légendaire :
                textToModify.color = Color.yellow;
                break;
            default:     
                break;


            
        }

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
