using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HailAnnounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float delay = 4.5f;

        gameObject.GetComponent<Text>().text = "It's about to hail!";
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
