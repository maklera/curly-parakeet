using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> _weapons = new Dictionary<string, int>();
    public Action OnInventoryChanged;
    private void OnEnable()
    {
        CollectableWeapon.OnWeaponPickUp += HandleWeaponPickedUp;
    }

    private void OnDisable()
    {
        CollectableWeapon.OnWeaponPickUp -= HandleWeaponPickedUp;
    }

    private void HandleWeaponPickedUp(WeaponData weaponData)
    {
        string itemId = weaponData.id;
        if (_weapons.TryGetValue(itemId, out int currentAmount) && currentAmount == 0)
            {
                Debug.Log("Weapon is non stackable we picked up");
            }
        else if(currentAmount >= 1 && weaponData.canStack)
        {
            Debug.Log("Weapon is stackable");
        }
        else if (currentAmount >= weaponData.maxStack)
        {
            //AddWeapon(weaponData);
        }
    }

    /*private void AddWeapon(WeaponData weaponData, int amount = 1);
    {
        if (weaponData == null)
    }*/
}
