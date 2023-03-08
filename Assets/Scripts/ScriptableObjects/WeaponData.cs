using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/WeaponData", order = 0)]


public class WeaponData : ScriptableObject
{
    //Using 4 enums to add some content easily
public enum WeaponRarity{Commun, Rare, Epique, Légendaire};
public enum WeaponTier{Magique, Physique};

public enum WeaponType{Principale, Secondaire};
public enum WeaponReach {Mêlée, Pugilat, Distance}




    public String WeaponName;
    public Sprite Image;
    public float Price; 
    //Set the price at float, if the weapon can cost floating amounts
    //Can be changed for ints if we can only pay with round amounts
    
    
    public WeaponRarity Rarity;
    public WeaponTier Tier;
    public WeaponType Type;
    public WeaponReach Reach;
    
    //Using float for easyer balancing
    public float Weight;
    public float Damages;
    public float Penetration;
    public float Speed;
    public float State;


}