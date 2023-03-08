using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/WeaponData", order = 0)]


public class WeaponData : ScriptableObject
{
public enum WeaponRarity{Commun, Rare, Epique, Légendaire};
public enum WeaponType{Principale, Secondaire};
public enum WeaponReach {Mêlée, Pugilat, Distance}




    public String WeaponName;
    public Sprite Image;
    public float Price;
    public WeaponRarity Rarity;
    public WeaponType Type;
    public WeaponReach Reach;
    public float Weight;
    public float Damages;
    public float Penetration;
    public float Speed;
    public float State;


}