using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    private Animator anim;
    private UIManager uiManager;

    [SerializeField] private Behaviour[] components;
    
    private void Awake()
    {
        currentHealth = startingHealth;
        uiManager = FindObjectOfType<UIManager>();
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth == 0)
        {
            GameOverScreen();
        }

    }

    //Add health to player
    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    //Restart game full health and enable components again
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.Play("Player_idle");

        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }

    //Enable game over screen when player dies, Disable selected components from player
    public void GameOverScreen()
    {
        if (!dead)
        {
            foreach (Behaviour component in components)
            {
                component.enabled = false;
            }

            dead = true;

            uiManager.GameOver();
        }
    }
}
