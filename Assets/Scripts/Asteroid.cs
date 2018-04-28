using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public int size;
    public Vector2 direction;
    private Rigidbody2D rb;
    public float speed;
    public GameObject _asteroid;
    public int health;
    public float scaleMag;



	// Use this for initialization
	void Start () {
        this.size = Random.Range(1, 5);
        initialize();
	}
	
	// Update is called once per frame
    void Update () {
        
    }

    void initialize() {
        if (size == 0) {
            Destroy(gameObject);
        }

        this.rb = GetComponent<Rigidbody2D>();
        this.speed = .03f;
        transform.localScale = new Vector3(this.size * scaleMag, this.size * scaleMag, 1);
    }

    private void onHit() {
        if(this.size > 0) {
            this.size--;
        }
    }
        
	private void FixedUpdate() {
        rb.AddForce(direction * speed);
	}

    public Vector2 rotateVector2(Vector2 vector, float degrees) {
        return Quaternion.Euler(0, 0, degrees) * vector;
    }

    public void breakAsteroid() {
        GameObject childOne = Instantiate(_asteroid, transform.position, transform.rotation, transform.parent);
        GameObject childTwo = Instantiate(_asteroid, transform.position, transform.rotation, transform.parent);
        Asteroid asteroidOne = childOne.GetComponent<Asteroid>();
        Asteroid asteroidTwo = childTwo.GetComponent<Asteroid>();

        asteroidOne.direction = rotateVector2(direction, 30f);
        asteroidTwo.direction = rotateVector2(direction, -30f);
        asteroidOne.size = size - 1;
        asteroidTwo.size = size - 1;
        asteroidOne.initialize();
        asteroidTwo.initialize();
        Destroy(gameObject);
    }
}
