using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ass")
			coll.gameObject.GetComponent<Asteriod> ().BreakAss ();
	}
}
