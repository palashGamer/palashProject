using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.input;

namespace com.palash.lineZen.gamePlay
{
	#region Initialization
	public partial class BallMovement : MonoBehaviour  {

		public Transform ball, m_Camera;

		float horizontalSpeed;
		float ballAutoVertSpeed;

		float ballDiameter;
		float ballCamDis;

		void Awake()
		{
			if (m_Camera == null)
				m_Camera = Camera.main.transform;

			CalculateVertHoriSpeed ();

		}
		void OnEnable()
		{
			Debug.Log ("onena");
			UserInput.instance.AddUserInputLstnr (this);
		}
		void OnDisable()
		{
			UserInput.instance.RemoveInputLstnr (this);
		}

		public void CalculateVertHoriSpeed()
		{
			float leftMostWorldPos = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,0)).x;
			float rightMostWorldPos = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,0)).x;
			float screenWorldDist = (rightMostWorldPos - leftMostWorldPos);

			horizontalSpeed = (screenWorldDist / Screen.width);
			horizontalSpeed *= ItemsData.instance.horizontalSpeedMultiplier;

			ballAutoVertSpeed = (screenWorldDist / Screen.height) * ItemsData.instance.ballAutoVertSpeedMultiplier;
			ballDiameter = this.GetComponent<SpriteRenderer> ().bounds.extents.x * 2;
			ballCamDis = m_Camera.transform.position.y - ball.transform.position.y;

			Debug.LogError ("speed: "+horizontalSpeed+" : "+rightMostWorldPos+" : "+leftMostWorldPos+" : "+Screen.width+" : "+ballDiameter);
		}

	}
	#endregion

	#region Input_Callbacks
	public partial class BallMovement : IInput{
		public void OnMouseMoved (float deltaX)
		{
			if (GameConstants.gameStatus == GameStatus.GameRunning) {

				Debug.Log ("<color=green> mouse moved received in ballmovement " + deltaX+" : "+(ballDiameter) + "</color>");
				float finalDeltaX = deltaX * horizontalSpeed;

				if(finalDeltaX>0)
					finalDeltaX = Mathf.Min (finalDeltaX, ballDiameter);
				else if(finalDeltaX<0)
					finalDeltaX = Mathf.Max (finalDeltaX, (-1) * ballDiameter);
				
				Debug.Log ("final delX using: "+finalDeltaX+" : "+horizontalSpeed);
				ball.transform.position += new Vector3 (finalDeltaX, 0, 0);
			}
		}
	}
	#endregion

	#region AutoMovement
	public partial class BallMovement{


		void Update()
		{
			if (GameConstants.gameStatus == GameStatus.GameRunning) {
				MoveBallUpward_Auto ();
			}
		}
		void MoveBallUpward_Auto()
		{
			ball.transform.position += new Vector3(0,ballAutoVertSpeed,0);
			m_Camera.position = new Vector3 (m_Camera.position.x,(ball.transform.position.y + ballCamDis),m_Camera.position.z);
		}
	}
	#endregion
}
