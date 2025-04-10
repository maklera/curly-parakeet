using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 50;
    
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthSlider;
    
    public delegate void PlayerStateChanged();
    public event PlayerStateChanged OnHealthChanged;
    
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public bool IsAlive => currentHealth > 0;
    
    private void Start()
    {
        UpdateHealthUI();
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
    
    public bool Heal(int healAmount)
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
    
    public bool Poison(int damageAmount)
    {
        if (!IsAlive)
        {
            Debug.Log("Already dead!");
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
    
    /*public bool Resurrect(int healthAmount)
    {
        if (IsAlive)
        {
            Debug.Log("Player is alive!");
            return false;
        }
        
        currentHealth = healthAmount;
        
        Debug.Log($"Player resurrected with {healthAmount} health!");
        UpdateHealthUI();
        
        if (OnHealthChanged != null)
            OnHealthChanged();
        
        return true;
    }*/
}