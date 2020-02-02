using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public GameObject character;
    public GameObject counter;
    public float speed;
    public float pushAmount;
	private Rigidbody2D characterBody;
	private float ScreenWidth;
    private TextMesh text;
    private int particleCount;
    private int yellowCount;
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pushAmount = 0.0f;
        text = counter.GetComponent<TextMesh>();
        particleCount = 0;
        yellowCount = 0;
        text.text = "Particles Collected: " + particleCount;
    }

    // Update is called once per frame
    void Update() {
        int i = 0;
        while(i < Input.touchCount) {
        	if(Input.GetTouch(i).position.x > ScreenWidth/2) {
        		RunCharacter(speed);
        	}
        	if(Input.GetTouch(i).position.x < ScreenWidth/2) {
        		RunCharacter(-speed);
        	}
        	++i;
        }
        if(GameObject.Find("Hail(Clone)") != null){
            pushDown(pushAmount, 0.1f);
        }
        if(GameObject.Find("Rain(Clone)") != null && gameObject.GetComponent<SpriteRenderer>().color == Color.blue){
            speed = 2.0f;
        }
        else if(GameObject.Find("Rain(Clone)") == null && gameObject.GetComponent<SpriteRenderer>().color != Color.blue){
            speed = 3.0f;
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
            character.transform.Translate(new Vector2(horizontalInput, characterBody.velocity.y) * speed * Time.deltaTime);
        }
        else {
            characterBody.velocity = new Vector2(0f, characterBody.velocity.y);
        }
    }

    public void pushDown(float amt, float length){
        pushAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }
    private Vector3 Pos;
    void BeginShake(){
        if(pushAmount > 0){
            Pos = transform.position;
            float offsetY = Random.value * pushAmount * 2 - pushAmount; 
            Pos.y += offsetY;

            transform.position = Pos;
        }
    }

    void StopShake(){
        CancelInvoke("BeginShake");
        transform.position = new Vector3(Pos.x, -3.97f, 0);
    }

     public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Obstacle") {
            Destroy(gameObject);
            return;
        }
        if(collider.gameObject.tag == "White") {
            anim.Play("White");
        }
        if(collider.gameObject.tag == "Red") {
            anim.Play("Red");
        }
        if(collider.gameObject.tag == "Yellow") {
            anim.Play("Yellow");
        }
        if(collider.gameObject.tag == "Blue") {
            anim.Play("Blue");
        }
        //controllerScript.particlePoints++;
        Destroy(collider.gameObject);
    }
}
