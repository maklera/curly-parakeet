using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private int gems = 0;
    // В будущем тут можно добавить другие предметы
    // [SerializeField] private int potions = 0;
    // [SerializeField] private int keys = 0;
    
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI gemText;
    
    public delegate void InventoryChanged();
    public event InventoryChanged OnGemsChanged;
    // Можно добавить события для других предметов
    
    public int Gems => gems;
    
    private void Start()
    {
        UpdateGemUI();
    }
    
    private void UpdateGemUI()
    {
        if (gemText != null)
        {
            gemText.text = gems.ToString();
        }
    }
    
    public void AddGem(int amount = 1)
    {
        gems += amount;
        UpdateGemUI();
        
        OnGemsChanged?.Invoke();
        
        Debug.Log($"Collected {amount} gem(s). Current: {gems}");
    }
    
    // Метод для использования гемов (если нужно)
    public bool UseGems(int amount)
    {
        if (gems >= amount)
        {
            gems -= amount;
            UpdateGemUI();
            OnGemsChanged?.Invoke();
            
            Debug.Log($"Used {amount} gems. Remaining: {gems}");
            return true;
        }
        
        Debug.Log($"Not enough gems. Required: {amount}, Available: {gems}");
        return false;
    }
    
    // Здесь могут быть другие методы для работы с инвентарем
}