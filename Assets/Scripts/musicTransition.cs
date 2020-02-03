using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTransition : MonoBehaviour
{
    private static musicTransition instance;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else{
            Destroy(gameObject);
        }
    }
}
