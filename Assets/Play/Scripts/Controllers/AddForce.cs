using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	/// <summary>
	/// This component is for blast-balls, just to add force @Start
	/// </summary>
	public class AddForce : MonoBehaviour {

		void Start () {
			Rigidbody2D rg = GetComponent<Rigidbody2D> ();
			float force = ItemsData.instance.blastForce;
			rg.AddForce (new Vector2(Random.Range(-1*force,force),Random.Range(-1*force,force)), ForceMode2D.Impulse);
		}
	}
}
