using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectSouls : MonoBehaviour
{
    public float souls;

    // Start is called before the first frame update
    void Start()
    {
        souls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soul"))
        {
            souls = souls + 1;
            Destroy(other.gameObject);
        }
    }
}
