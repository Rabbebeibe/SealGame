using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectSouls : MonoBehaviour
{
    public float souls;
    public TextMeshProUGUI numberOfSouls;
    private UIManager uiManager;
    [SerializeField] private Behaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        souls = 0;
        uiManager = FindObjectOfType<UIManager>();
    }

    //Collect souls by touching them and also add it to UI
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soul"))
        {
            souls = souls + 1;
            Destroy(other.gameObject);

            numberOfSouls.text = souls.ToString();

            //Check if player have collected every souls and enable win screen
            if(souls == 18)
            {
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                uiManager.YouWin();
            }
        }
    }
}
