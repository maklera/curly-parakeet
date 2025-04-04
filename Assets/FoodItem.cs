using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FoodItem : MonoBehaviour, IPointerClickHandler
{
    public enum ItemType { Healing, Poison, Resurrection }
    
    [SerializeField] private ItemType itemType;
    [SerializeField] private int healAmount = 20;
    [SerializeField] private int damageAmount = 20;
    [SerializeField] private int costAmount = 20;
    [SerializeField] private int resurrectionAmount = 1;
    private Player playerReference;
    
    private void Start()
    {
        // Find the player in the scene
        playerReference = FindObjectOfType<Player>();
        
        if (playerReference == null)
        {
            Debug.LogError("Player not found in the scene! Make sure there's a GameObject with Player component.");
        }
    }
    
    // This method is called when the food item is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }
    
    // Can also be called from a button
    public void UseItem()
    {
        if (playerReference != null)
        {
            switch (itemType)
            {
                case ItemType.Healing:
                    playerReference.Heal(healAmount, costAmount);
                    break;
                case ItemType.Poison:
                    playerReference.Poison(damageAmount, costAmount);
                    break;
                case ItemType.Resurrection:
                    playerReference.Resurrect(resurrectionAmount, costAmount);
                    break;
            }
        }
        else
        {
            Debug.LogError("Cannot use item: Player reference not found!");
        }
    }
}