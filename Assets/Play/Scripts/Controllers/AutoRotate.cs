using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

	Transform trans;

	// Use this for initialization
	void Start () {
		trans = this.GetComponent<Transform> ();	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,1f);
	}
}
