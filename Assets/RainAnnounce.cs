using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainAnnounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int delay = 5;

        gameObject.GetComponent<Text>().text = "It's about to rain!";
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
