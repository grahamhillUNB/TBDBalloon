using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public Animator music;
	public float wait;

	void Awake() {
		GameObject obj = GameObject.Find("BackgroundMusic");
		if(obj != null){
			music = obj.GetComponent<Animator>();
		}
	}
    public void LoadLevel(string name){
		Debug.Log ("New Scene load: " + name);
		StartCoroutine(ChangeScene(name));
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	IEnumerator ChangeScene(string name){
		music.SetTrigger("fadeOut");
		yield return new WaitForSeconds(wait);
		SceneManager.LoadScene(name);
	}
}
