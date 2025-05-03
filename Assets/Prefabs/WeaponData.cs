using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon/Melee")]
public class WeaponData : ScriptableObject
{
    public string id;
    public string displayName;
    public float damage;
    public float staminaCoast;
    public float durability;
    public int cost;
    public Sprite sprite;
    public bool canStack;
    public int maxStack;
}
