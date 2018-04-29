using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool isLeftActive{ get; set; }
	public bool isRightActive{ get; set; }
	public bool canScale{ get; set; }

	public Player player;
	public Weapon weapon;
	public Transform leftHand;
	public Transform rightHand;
	public Rigidbody2D rb;

	public float scaleMag;

	public bool canMove { get; set; }

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		weapon = GetComponent<Weapon> ();
	}

	void Update()
	{
		//Right Hand determines direction
		if (!isLeftActive)
			updateRotation();

		//Right hand depth determines acceleration
		if (isLeftActive && rightHand && canScale)
			scalePlayer ();
		else if (rightHand.transform.position.z > 2.5f)
			moveForward ();
	}

	void updateRotation()
	{
		Vector3 vectorToTarget = rightHand.position - Vector3.zero;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation,q, 10f);
	}

	void moveForward()
	{
		rb.AddForce (transform.right * 40, ForceMode2D.Force);
	}

	public void scalePlayer(){
		float distance = Vector3.Distance (leftHand.position, rightHand.position);
		//Debug.Log (distance);
		distance = Mathf.Clamp (distance, 3, 9);

		float normalizedDistance = (distance - 3) / (9 - 3);
		Debug.Log (normalizedDistance);

		player.scaleFactor = normalizedDistance;

		weapon.bulletSize = Mathf.Clamp(normalizedDistance * 0.8f, 0.2f, 0.8f);

		transform.localScale = new Vector3 (normalizedDistance * scaleMag + 0.1f, normalizedDistance * scaleMag + 0.1f, normalizedDistance * scaleMag + 0.1f);

	}
		
	public void test(){

	}
}
