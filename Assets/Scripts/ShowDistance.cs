using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDistance : MonoBehaviour
{
    public GameObject enemy;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI pbText;
    private Vector3 startPos;
    private float distance;
    private float pb;

    // Start is called before the first frame update
    void Start()
    {
        startPos = enemy.transform.position;
        pb = PlayerPrefs.GetFloat("pb", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(startPos, enemy.transform.position);
        distanceText.text = "distance: " + distance.ToString("F2");
        pbText.text = "Personal Best: " + pb.ToString("F2");

        if (distance > pb)
        {
            pb = distance;
            PlayerPrefs.SetFloat("pb", pb);
        }
        
        
    }
}
