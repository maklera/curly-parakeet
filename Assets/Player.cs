using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 50;
    [SerializeField] private int currentGold = 100;
    
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI goldText;
    
    public delegate void PlayerStateChanged();
    public event PlayerStateChanged OnHealthChanged;
    public event PlayerStateChanged OnGoldChanged;
    
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public int CurrentGold => currentGold;
    public bool IsAlive => currentHealth > 0;
    
    private void Start()
    {
        UpdateHealthUI();
        UpdateGoldUI();
    }
    
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
    
    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = currentGold.ToString();
        }
    }
    
    public bool CanAfford(int cost)
    {
        return currentGold >= cost;
    }
    
    public bool SpendGold(int amount)
    {
        if (!CanAfford(amount))
        {
            Debug.Log($"Not enough gold! Need: {amount}, Current: {currentGold}");
            return false;
        }
        
        currentGold -= amount;
        UpdateGoldUI();
        
        if (OnGoldChanged != null)
            OnGoldChanged();
        
        return true;
    }
    
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
        
        if (OnGoldChanged != null)
            OnGoldChanged();
        
        Debug.Log($"Spent {amount} gold. Current: {currentGold}");
    }
    
    public bool Heal(int healAmount, int costAmount)
    {
        if (!IsAlive)
        {
            Debug.Log("Already dead! First resurrection!.");
            return false;
        }
        
        if (currentHealth >= maxHealth)
        {
            Debug.Log("Already at full health!");
            return false;
        }
        
        if (!SpendGold(costAmount))
        {
            return false;
        }
        
        currentHealth += healAmount;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        Debug.Log($"Healed for {healAmount}. Current health: {currentHealth}/{maxHealth}");
        UpdateHealthUI();
        
        if (OnHealthChanged != null)
            OnHealthChanged();
        
        return true;
    }
    
    public bool Poison(int damageAmount, int costAmount)
    {
        if (!IsAlive)
        {
            Debug.Log("Already dead!");
            return false;
        }
        
        if (!SpendGold(costAmount))
        {
            return false;
        }
        
        currentHealth -= damageAmount;
        
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log($"Damaged for {damageAmount}. Player killed!");
        }
        else
        {
            Debug.Log($"Damaged for {damageAmount}. Current health: {currentHealth}/{maxHealth}");
        }
        
        UpdateHealthUI();
        
        if (OnHealthChanged != null)
            OnHealthChanged();
        
        return true;
    }
    
    public bool Resurrect(int healthAmount, int costAmount)
    {
        if (IsAlive)
        {
            Debug.Log("Player is alive!");
            return false;
        }
        
        if (!SpendGold(costAmount))
        {
            return false;
        }
        
        currentHealth = healthAmount;
        
        Debug.Log($"Player resurrected with {healthAmount} health!");
        UpdateHealthUI();
        
        if (OnHealthChanged != null)
            OnHealthChanged();
        
        return true;
    }
}