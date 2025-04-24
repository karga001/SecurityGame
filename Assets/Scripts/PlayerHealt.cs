using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;                    // Oyuncunun maksimum sa�l���
    public RawImage[] hearts;                    // 3 adet kalp i�in RawImage dizisi
    public Texture fullHeart;                    // Dolu kalp g�rseli
    public Texture emptyHeart;                   // Bo� kalp g�rseli
    private int currentHealth;                   // Anl�k sa�l�k durumu

    void Start()
    {
        
        currentHealth = maxHealth;
        UpdateHearts();  
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                          
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);   
        UpdateHearts(); 
        Debug.Log("Oyuncu �ld�");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Oyuncu �ld�!");
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Oyuncuya de�di");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);              
            }
        }
    }


    
    void UpdateHearts()
    {
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            { 
                hearts[i].texture = fullHeart;   // Sa�l�k varsa dolu kalp
            }
            else
            {
                hearts[i].texture = emptyHeart;  // Sa�l�k yoksa bo� kalp
            }
        }
    }

}
