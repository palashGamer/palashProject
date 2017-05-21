using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	public class SOSnonGravityController : MonoBehaviour {

		public GameObject[] Objects;

		void Start()
		{
			Vector3 thisPos = this.transform.position;

			for (int count = 0; count < Objects.Length; count++) {
				
				Objects [count].transform.position = new Vector3 (thisPos.x + Random.Range(-1.95f,1.95f), thisPos.y+Random.Range(-1.5f,1.5f), thisPos.z);
				Objects [count].SetActive (true);

				if (Random.Range (0, 2) == 1) {
					Objects [count].tag = GameConstants.SOS_TAG;
					Objects [count].GetComponent<SpriteRenderer> ().color = ItemsData.instance.sosColor;
				}
				else {
					Objects [count].tag = GameConstants.ROAD_TAG;
					Objects [count].GetComponent<SpriteRenderer> ().color = ItemsData.instance.barrierColor;
				}
			}
		}
	}
}
