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

        if (currentHealth > 0)
        {
            
        }

        else
        {
            GameOverScreen();
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

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
