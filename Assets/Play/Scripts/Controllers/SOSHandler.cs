using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSHandler : MonoBehaviour {

	bool gravityEnabled = false;
	void Start()
	{
		if (Random.Range (0, 3) == 0) {
			StartCoroutine (EnableGravity());
		}
	}
	void OnBecameVisible()
	{
		StartCoroutine (EnableGravity());

	}
	void OnBecameInvisible()
	{
		Debug.LogError ("SOS became invisible");
		Destroy (this.gameObject);
	}

	IEnumerator EnableGravity()
	{
		if (gravityEnabled)
			yield break;
		
		yield return new WaitForSeconds (0.25f);
		Rigidbody2D rgdbdy = GetComponent<Rigidbody2D> ();
		if (rgdbdy != null) {
			rgdbdy.gravityScale = Random.Range(0.03f,0.095f);
		}
		gravityEnabled = true;
	}
}
