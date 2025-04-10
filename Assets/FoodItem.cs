using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public enum ItemType { Healing, Poison }
    
    [Header("Item Properties")]
    [SerializeField] private ItemType itemType;
    [SerializeField] private int healAmount = 20;
    [SerializeField] private int damageAmount = 20;
    
    [Header("Sound Effects")]
    [SerializeField] private AudioClip useSound;
    [SerializeField] private float volume = 1f;
    
    [Header("Options")]
    [SerializeField] private bool destroyOnUse = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player playerReference = other.GetComponent<Player>();
            
            if (playerReference != null)
            {
                bool itemUsed = false;
                
                switch (itemType)
                {
                    case ItemType.Healing:
                        itemUsed = playerReference.Heal(healAmount);
                        break;
                        
                    case ItemType.Poison:
                        itemUsed = playerReference.Poison(damageAmount);
                        break;
                }
                
                if (itemUsed)
                {
                    // Проигрываем звук, если он назначен
                    if (useSound != null)
                    {
                        AudioSource.PlayClipAtPoint(useSound, transform.position, volume);
                    }
                    
                    // Уничтожаем объект после использования, если настроено
                    if (destroyOnUse)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}