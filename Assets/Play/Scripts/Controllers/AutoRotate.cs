using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{

	//This script can be used to rotate anything 
	public class AutoRotate : MonoBehaviour {

		Transform trans;
		Vector3 rotationVector = new Vector3(0,0,1);

		void Start () {
			trans = this.GetComponent<Transform> ();
			InvokeRepeating ("myUpdate",0,Time.deltaTime*2);
		}

		void myUpdate () {
			transform.Rotate (rotationVector);
		}

		void OnDestroy()
		{
			CancelInvoke ();
		}
	}
}
