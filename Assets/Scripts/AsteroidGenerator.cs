using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {


    public const int MAX_ASTEROIDS = 10;
    public int totalAsteroids;
    public GameObject _asteroid;


	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnRandomAsteroid", 2, 3);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnRandomAsteroid() {
        this.totalAsteroids++; //Increase total asteroid count
        Vector3 randomPos = Camera.main.ViewportToWorldPoint(createRandomVector());

        GameObject asteroidClone = Instantiate(_asteroid, randomPos, Quaternion.identity, this.transform);
        Asteroid cloneData = asteroidClone.GetComponent<Asteroid>();
        cloneData.direction = transform.position - asteroidClone.transform.position;

    }

    public Vector3 createRandomVector() {
        //Left-Right and Top-Bottom Flags
        float xPosition = Random.Range(-0.2f, 1.2f);
        float yPosition;
        Debug.Log("X Position: " + xPosition);

        if (xPosition <= 1.1 && xPosition >= -0.05)
        { //xPosition is inside viewPort, y must be outside
            if (Random.Range(0, 2) == 1)
            { //flag for top, y must be greater than 1
                yPosition = Random.Range(1.2f, 1.4f);
            }
            else
            { // flag set to bottom 
                yPosition = Random.Range(-0.4f, -0.2f);
            }

        }
        else
        { // xPosition is outside viewPort, y has freedom 
            yPosition = Random.Range(-0.4f, 1.4f);
        }

        Vector3 randomVector = new Vector3(xPosition, yPosition, 0);
        return randomVector;
    }



}
