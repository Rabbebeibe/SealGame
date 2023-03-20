using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSouls : MonoBehaviour
{

    public float rSpeed;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private Behaviour[] components;

    // Update is called once per frame
    void Update()
    {
        //Spin sprite
        transform.Rotate(0, 0, rSpeed);

        // When either win or lose screen is active souls stop rotating
        if (uiManager.gameOverScreen.activeSelf == true || uiManager.youWinScreen.activeSelf == true)
        {
            stopMovement();
        }
    }

    public void stopMovement()
    {
        //Disable selected components
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
        
        rSpeed = 0;

    }
}
