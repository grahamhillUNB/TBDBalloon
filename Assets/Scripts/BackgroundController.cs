using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private RectTransform obj;
    private Vector3 start;
    private Vector3 target;
    public float speed;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<RectTransform>();
        start = obj.transform.position;
        target = new Vector3(start.x + 89,start.y, start.z);
        speed = 0.25f;
        distance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
       obj.transform.position =  Vector3.Lerp(start, target, distance);
       distance += speed * Time.deltaTime;
       if(distance >= 1){
           distance = 0.0f;
           Vector3 temp = start;
           start = target;
           target = temp;
       }
       //Debug.Log(target);
    }
}
