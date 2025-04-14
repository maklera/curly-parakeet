using UnityEngine;
using System;

public class CollectableWeapon : MonoBehaviour
{
    public static Action<WeaponData> OnWeaponPickUp;
    private WeaponData weaponData;
    
    private SpriteRenderer _spriteRenderer;

    public void SetWeaponData(WeaponData data)
    {
        weaponData = data;
        
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = data.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        OnWeaponPickUp?.Invoke(weaponData);
        Destroy(gameObject);
    }
}
