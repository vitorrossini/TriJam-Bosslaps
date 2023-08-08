using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suitcase : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb2d;
    public bool charging = true;
    public bool canSlap = true;
    public float throwForceHorizontal;
    public float throwForceVertical;
    public float multiplier = 1f;
    public bool raising = true;
    public bool falling = false;
    private Animator _animator;
    public PowerUI powerUI;
    private AudioSource slapSound;
    public Button slapButton;
  
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        powerUI.SetMaxPower(2f);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(3,7);
        _animator = GetComponentInParent<Animator>();
        powerUI = GameObject.Find("powerThing").GetComponent<PowerUI>();
        slapSound = GetComponent<AudioSource>();
        canSlap = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canSlap)
        {
                
                if (multiplier <= 1f && canSlap)
                {
                    raising = true;
                    falling = false;
                }

                else if (multiplier >= 2f && canSlap)
                {
                    raising = false;
                    falling = true;
                }
                
                if (raising)
                {
                    Increasing();
                }

                if (falling)
                {
                    Decreasing();
                }
                
                powerUI.SetPower(multiplier);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log(collision.gameObject.tag);
        }
        else
        {
            Debug.Log("hit something else");
            
        }
    }

    public void Slap()
    {
        _animator.Play("player"); 
        Invoke("SuitcaseGo", 0.15f);
        slapButton.interactable = false;
        Debug.Log("pirituber");
    }

    private void SuitcaseGo()
    {
        if (canSlap)
        {
            rb2d.AddForce(
                transform.right * throwForceHorizontal * multiplier * 1.2f + transform.up * throwForceVertical * multiplier,
                ForceMode2D.Impulse);
            slapSound.Play();
            canSlap = false;

            falling = false;
            raising = false;
            charging = false;
        }
    }

    private void Increasing()
    {
        multiplier += Time.deltaTime * 0.5f;

    }
    
    private void Decreasing()
    {
        multiplier -= Time.deltaTime * 0.5f;
        
    }

   
}
