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

    //The 3 fields are used to show if the displayed weapon is better than the previous
    private float _previousDamages;
    private float _previousPenetration;
    private float _previousSpeed;
    void Start()
    {
        //Going to the first index on the first call
        if (DatabaseManager.Instance.WeaponData.Count >= 0)
        {
            //We initialise the first element as itself, so it don't show any comparisons
            LoadPreviousWeapon(0);
            
            LoadWeapon(DatabaseManager.Instance.WeaponData[0]);
            _actualIndex = 0;
        }
    }
    /// <summary>
    /// called when changing the weapon to keep in memory the previous weapon to compare on display
    /// </summary>
    /// <param name="previousIndex">the index of the previous weapon in the list of the DatabaseManager</param>

    private void LoadPreviousWeapon(int previousIndex)
    {
        //This function is 
        _previousDamages = DatabaseManager.Instance.WeaponData[previousIndex].Damages;
        _previousPenetration = DatabaseManager.Instance.WeaponData[previousIndex].Penetration; 
        _previousSpeed = DatabaseManager.Instance.WeaponData[previousIndex].Speed;
    }
    
    /// <summary>
    /// Load on the displayer the weapon we want to load
    /// </summary>
    /// <param name="weaponToDisplay">The datas of the weapon we want to display</param>
    public void LoadWeapon(WeaponData weaponToDisplay)
    {
        //Loading all the texts we just want to display, we'll use functions for harder displays
        //such as colors changing depending of an enum
        _name.text = weaponToDisplay.WeaponName;
        _price.text = weaponToDisplay.Price + " Po";
        _type.text = "Arme de " + weaponToDisplay.Reach + " " + weaponToDisplay.Type;
        _weight.text = weaponToDisplay.Weight + " Kg";
        _imageToDisplay.sprite  = weaponToDisplay.Image;

        //Complex displays
        DisplayTier(_tier, weaponToDisplay.Tier, weaponToDisplay.Rarity);
        DisplayDamages(_damage, weaponToDisplay.Damages);
        DisplayPenetrations(_penetration, weaponToDisplay.Penetration);
        DisplaySpeed(_speed, weaponToDisplay.Speed);
        DisplayState(_state, weaponToDisplay.State);

    }
    /// <summary>
    /// Used to display the damages of the new weapon and compare it to the previous one
    /// </summary>
    /// <param name="textToModify">A reference to the text-mesh on witch we want to display the text</param>
    /// <param name="damage">The amount of damages the weapon deals</param>

    private void DisplayDamages(TextMeshProUGUI textToModify, float damage)
    {
        if (damage < _previousDamages)
        {
            textToModify.text = damage + "<color=red> - " + (_previousDamages - damage) + " </color>";
        }
        else if (damage > _previousDamages)
        {
            textToModify.text = damage + "<color=green> + " + (damage - _previousDamages) + " </color>";
        }
        else
        {
            textToModify.text = damage.ToString();
        }
    }
    
    /// <summary>
    /// Used to display the penetration of the new weapon and compare it with the previous one
    /// </summary>
    /// <param name="textToModify">A reference to the text-mesh on witch we want to display the text</param>
    /// <param name="penetration">The amount of penetration the weapon posses</param>

    private void DisplayPenetrations(TextMeshProUGUI textToModify, float penetration)
    {
        if (penetration < _previousPenetration)
        {
            textToModify.text = penetration + "<color=red> - " + (_previousPenetration - penetration) + " </color>";
        }
        else if (penetration > _previousPenetration)
        {
            textToModify.text = penetration + "<color=green> + " + (penetration - _previousPenetration) + " </color>";
        }
        else
        {
            textToModify.text = penetration.ToString();
        }
    }
    /// <summary>
    /// Used to display the speed of the new weapon and compare it with the previous one
    /// </summary>
    /// <param name="textToModify">A reference to the text-mesh on witch we want to display the text</param>
    /// <param name="speed">The speed of the weapon</param>
    private void DisplaySpeed(TextMeshProUGUI textToModify, float speed)
    {
        if (speed < _previousSpeed)
        {
            textToModify.text = speed + "<color=red> - " + (_previousSpeed - speed) + " </color>";
        }
        else if (speed > _previousSpeed)
        {
            textToModify.text = speed + "<color=green> + " + (speed - _previousSpeed) + " </color>";
        }
        else
        {
            textToModify.text = speed.ToString();
        }
    }
    
    /// <summary>
    /// Used to display the state of the weapon (%) and give it a name of the state and a color
    /// </summary>
    /// <param name="textToModify">A reference to the text-mesh on witch we want to display the text</param>
    /// <param name="state">The % of condition of the weapon</param>
    private void DisplayState(TextMeshProUGUI textToModify, float state)
    {
        //Using else If, since we want to check if the state is between two values
        //We use the <color> markdown to colorize only half the text
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
        }else /*if (state >= 80)*/
        {
            textToModify.text = "Neuve <color=green>" + state.ToString()+ "%</color>";
        }
        
        
    }
    
    /// <summary>
    /// Used to display the tier of the weapon and give it a color depending of the rarity
    /// </summary>
    /// <param name="textToModify">A reference to the text-mesh on witch we want to display the text</param>
    /// <param name="tier">The tier of the weapon (magic of physic)</param>
    /// <param name="rarity">The rarity of the weapon)</param>

    private void DisplayTier(TextMeshProUGUI textToModify, WeaponData.WeaponTier tier, WeaponData.WeaponRarity rarity)
    {
        // Switching on the rarity to display the correct color
        textToModify.text = tier + " - " + rarity;
        switch (rarity)
        {
            case WeaponData.WeaponRarity.Commun :
                textToModify.color = Color.white;
                break;
            case WeaponData.WeaponRarity.Rare :
                //Using Cyan since Blue is almost unseeable with the background
                textToModify.color = Color.cyan;
                break;

            case WeaponData.WeaponRarity.Epique :
                textToModify.color = Color.magenta;
                break;

            case WeaponData.WeaponRarity.Légendaire :
                textToModify.color = Color.yellow;
                break;
            default:     
                break;
            //Default should not be reachable

            
        }

    }
    
    
    /// <summary>
    /// Used to display the next weapon in the list, used in the onclick of a button
    /// </summary>

    public void NextWeapon()
    {
        //Going to the next weapon in the list
        LoadPreviousWeapon(_actualIndex);
        _actualIndex += 1;
        if (_actualIndex >= DatabaseManager.Instance.WeaponData.Count)
        {
            //if the next weapon is outside of the list, we go to the first one
            _actualIndex = 0;
        }

        LoadWeapon(DatabaseManager.Instance.WeaponData[_actualIndex]);
    }
    /// <summary>
    /// Used to display the previous weapon in the list, used in the onclick of a button
    /// </summary>

    public void PreviousWeapon()
    {        
        LoadPreviousWeapon(_actualIndex);
        //Going to the previous weapon in the list
        _actualIndex -= 1;
        if (_actualIndex < 0)
        {
            //if the previous weapon is outside of the list, we go to the last one

            _actualIndex = DatabaseManager.Instance.WeaponData.Count-1;
        }

        LoadWeapon(DatabaseManager.Instance.WeaponData[_actualIndex]);
    }

    
  
  
}
