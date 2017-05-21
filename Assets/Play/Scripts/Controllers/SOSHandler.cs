using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{

	/// <summary>
	/// SOS handler. This class handles SOS balls...
	/// </summary>
	public class SOSHandler : MonoBehaviour {

		bool gravityEnabled = false;

		#region Unity's callbacks
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
		#endregion

		#region helper methods
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
		#endregion
	}
}
