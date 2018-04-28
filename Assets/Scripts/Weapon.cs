using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public bool canFire { get; set; }

	public float fireRate;
	public float bulletSize;

	public bool fireRateUpgrade;
	public bool fireSizeUpgrade;

	private GameObject bullet;
	private bool inFireCoroutine;

	void Start(){
		bullet = Resources.Load ("Bullet") as GameObject;
	}

	void Update(){
		if (!inFireCoroutine && canFire)
			StartCoroutine (Fire ());
	}

	public IEnumerator Fire()
	{
		inFireCoroutine = true;
		GameObject _bullet = Instantiate (bullet,transform.position, Quaternion.identity);
		_bullet.transform.localScale = new Vector3 (bulletSize, bulletSize, bulletSize);
		_bullet.GetComponent<Rigidbody2D> ().AddForce (transform.right * 20);
		yield return new WaitForSeconds(1f/fireRate);
		inFireCoroutine = false;
	}
}
