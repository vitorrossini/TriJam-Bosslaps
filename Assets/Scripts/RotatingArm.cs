using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArm : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer _sprite;

    private float rotationZ;
    // Start is called before the first frame update
    void Start()
    {
        rotationZ = gameObject.transform.rotation.z;
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
       // rotationZ = Mathf.Clamp(rotationZ, 0, 75); // This only allows the rotation between -90 and 90 degrees
       ArmAim();

    }

    private void ArmAim()
    {
        rotationZ = Mathf.PingPong(Time.time * speed, 75f);
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    public void HideArmAfterHit()
    {
        _sprite.color = new Color(1, 1, 1, 0);
    }
    
}
