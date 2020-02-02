using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadLevel(string name){
		Debug.Log ("New Scene load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
