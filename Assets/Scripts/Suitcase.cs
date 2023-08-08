using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Suitcase : MonoBehaviour
{
    [Space(20)]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movingArm;
    
    private Rigidbody2D rb2d;
    private Animator _animator;
    private RotatingArm _rotatingArm;
    private AudioSource slapSound;
    public PowerUI powerUI;
    public Button slapButton;
    
    private bool canSlap = true;
    private float powerBarValue;
    
    [Space(20)]
    public float throwForce = 50f;
    public float barSpeed = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(3,7);
        _animator = GetComponentInParent<Animator>();
        powerUI = GameObject.Find("powerThing").GetComponent<PowerUI>();
        slapSound = GetComponent<AudioSource>();
        _rotatingArm = movingArm.GetComponent<RotatingArm>();
        canSlap = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canSlap)
        {
            powerBarValue = Mathf.PingPong(Time.time * barSpeed, 3f);
            powerUI.SetPower(powerBarValue);
            
        }
    }

    public void Slap()
    {
        _animator.Play("player"); 
        Invoke("SuitcaseGo", 0.15f);
        slapButton.interactable = false;
        Debug.Log("pirituber");
        _rotatingArm.HideArmAfterHit();
    }

    private void SuitcaseGo()
    {
        if (canSlap)
        {
            
            rb2d.AddForce(movingArm.transform.right * throwForce * powerBarValue, ForceMode2D.Impulse);
            slapSound.Play();
            canSlap = false;

        }
    }


   
}
