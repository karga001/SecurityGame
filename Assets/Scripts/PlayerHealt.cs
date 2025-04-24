using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;                    // Oyuncunun maksimum saðlýðý
    public RawImage[] hearts;                    // 3 adet kalp için RawImage dizisi
    public Texture fullHeart;                    // Dolu kalp görseli
    public Texture emptyHeart;                   // Boþ kalp görseli
    private int currentHealth;                   // Anlýk saðlýk durumu

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
        Debug.Log("Oyuncu Öldü");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Oyuncu öldü!");
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Oyuncuya deðdi");
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
                hearts[i].texture = fullHeart;   // Saðlýk varsa dolu kalp
            }
            else
            {
                hearts[i].texture = emptyHeart;  // Saðlýk yoksa boþ kalp
            }
        }
    }

}
