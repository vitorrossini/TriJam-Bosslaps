using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPit : MonoBehaviour
{
    private UIMenu retryButton;
    [SerializeField] private GameObject boss;

    private void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<UIMenu>();
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == boss)
        {
            retryButton.Retry();
            Debug.LogError("DeathPit");
        }
    }
}
