using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public GameObject character;
    public float speed;
    private AudioSource source;
    public AudioClip[] sounds;
	private Rigidbody2D characterBody;
	private float ScreenWidth;

    // Start is called before the first frame update
    void Start() {
        source = gameObject.GetComponent<AudioSource>();
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        int i = 0;
        while(i < Input.touchCount) {
        	if(Input.GetTouch(i).position.x > ScreenWidth/2) {
        		RunCharacter(speed);
                source.clip = sounds[0];
                source.Play();
        	}
        	if(Input.GetTouch(i).position.x < ScreenWidth/2) {
        		RunCharacter(-speed);
                source.clip = sounds[1];
                source.Play();
        	}
        	++i;
        }
    }
    void FixedUpdate() {
    	#if UNITY_EDITOR
    	RunCharacter(Input.GetAxis("Horizontal"));
    	#endif
    }

    private void RunCharacter(float horizontalInput) {
        float width = character.GetComponent<Renderer>().bounds.size.x;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    	if(horizontalInput < 0f && characterBody.position.x > leftBorder + width/2 || horizontalInput > 0f && characterBody.position.x < rightBorder - width/2) {
            character.transform.Translate(new Vector2(horizontalInput, characterBody.velocity.y) * Time.deltaTime);
            Debug.Log("I am Moving");
        }
        else {
            characterBody.velocity = new Vector2(0f, characterBody.velocity.y);
        }
    }
}
