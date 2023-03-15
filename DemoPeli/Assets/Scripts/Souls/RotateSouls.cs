using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSouls : MonoBehaviour
{

    public float rSpeed;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private Behaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rSpeed);

        if (uiManager.gameOverScreen.activeSelf == true || uiManager.youWinScreen.activeSelf == true)
        {
            stopMovement();
        }
    }

    public void stopMovement()
    {

        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
        
        rSpeed = 0;

    }
}
