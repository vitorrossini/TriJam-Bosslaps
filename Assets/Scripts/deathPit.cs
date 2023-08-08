using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPit : MonoBehaviour
{
    private UIMenu retryButton;

    private void Start()
    {
        retryButton = GameObject.Find("Menu").GetComponent<UIMenu>(); // game object where the Retry function is
        
    }

   
    private void OnCollisionEnter2D(Collision2D col) // death pit looks for the boss sprite
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            retryButton.Retry();
        }
    }
}
     