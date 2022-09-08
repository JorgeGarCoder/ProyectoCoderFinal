using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]

public class ScriptWeaponSO : ScriptableObject
{
    public Sprite weaponSprite;

    public string weaponName;
    
    public int weaponPriceInt;
    public string weaponCountryOfOriginSg;
    public float weaponCaliberFlo;
    public int weaponClipCapacityInt;
    public int weaponRateOfFireInt;
    public float weaponWeightLoadedFlo;
    public float weaponProjectileWeightFlo;
    public int weaponMuzzleVelocityInt;
    public int weaponMuzzleEnergyInt;
}
