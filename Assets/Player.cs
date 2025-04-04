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
    
    public void Heal(int healAmount, int costAmount)
    {
        // Check if player needs healing
        if (currentHealth < maxHealth && currentHealth != 0 && currentGold > 0)
        {
            // Add healing amount
            currentHealth += healAmount;
            currentGold -= costAmount;
            
            // Make sure we don't exceed max health
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            
            Debug.Log($"Healed for {healAmount}. Current health: {currentHealth}/{maxHealth}");
            UpdateHealthUI();
            UpdateGoldUI();
        }
        else
        {
            Debug.Log("Already at full health!");
        }
    }
    
    public void Poison(int damageAmount, int costAmount)
    {
        // Check if player needs healing
        if (currentHealth > 0 && currentGold > 0)
        {
            // Add healing amount
            currentHealth -= damageAmount;
            currentGold -= costAmount;
            
            // Make sure we don't exceed max health
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            
            Debug.Log($"Damaged for {damageAmount}. Current health: {currentHealth}/{maxHealth}");
            UpdateHealthUI();
            UpdateGoldUI();
        }
        else
        {
            Debug.Log("Already dead!");
        }
    }
    
    private void Start()
    {
        UpdateHealthUI();
        UpdateGoldUI();
    }
}