using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSnonGravityCollision : MonoBehaviour {

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Player")) {
			Rigidbody2D rg = this.GetComponent<Rigidbody2D> ();

			if (rg != null) {
				rg.AddForce (new Vector2(Random.Range(0.5f,0.95f), Random.Range(0.5f,0.95f)));
				Debug.Log ("adding force");
			}
		}
	}
}
