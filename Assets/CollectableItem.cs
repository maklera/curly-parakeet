using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private bool isGem = true;
    [SerializeField] private int amount = 1; // Количество предметов
    
    [Header("Sound")]
    [SerializeField] private AudioClip collectSound; // Звук подбора
    [SerializeField] private float volume = 1f; // Громкость звука
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isGem)
            {
                // Сначала ищем инвентарь на объекте игрока
                Inventory inventory = other.GetComponent<Inventory>();
                
                // Если не нашли на игроке, ищем в сцене
                if (inventory == null)
                {
                    inventory = FindObjectOfType<Inventory>();
                }
                
                if (inventory != null)
                {
                    // Проигрываем звук, если он назначен
                    if (collectSound != null)
                    {
                        // Воспроизводим звук на месте объекта
                        AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
                    }
                    
                    inventory.AddGem(amount);
                    Destroy(gameObject);
                    Debug.Log("Gem collected");
                }
            }
        }
    }
}