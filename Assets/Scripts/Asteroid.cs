using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public int size;
    public Vector2 direction;
    private Rigidbody2D rb;
    public float speed;

	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.size = Random.Range(1, 5);
        this.speed = .03f;   
	}
	
	// Update is called once per frame
    void Update () {
        
    }


    private void onHit() {
        if(this.size > 0) {
            this.size--;
        }
    }
        
	private void FixedUpdate() {
        rb.AddForce(direction * speed);
	}

}
