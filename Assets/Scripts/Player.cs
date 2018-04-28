using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player")]
public class Player : ScriptableObject {

	public int lives;
	public float scaleFactor;

	public float accleration; 

	public bool invincibleUpgrade;

}
