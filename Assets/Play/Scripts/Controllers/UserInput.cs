using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.input
{
	public class UserInput : MonoBehaviour {

		public static UserInput instance;

		void Awake()
		{
			//assigning singleton
			if (instance != null && instance != this)
				Destroy (this.gameObject);

			if (instance == null)
				instance = GetComponent<UserInput> ();

			DontDestroyOnLoad (this.gameObject);
			#if gameRunning
			GameConstants.gameStatus = GameStatus.GameRunning;
			#endif
		}

		List<IInput> userInputListeners = new List<IInput>();
		public void AddUserInputLstnr(IInput input){
			if (!userInputListeners.Contains (input)) {
				userInputListeners.Add (input);
			}
		}
		public void RemoveInputLstnr(IInput input)
		{
			if (userInputListeners.Contains (input)) {
				userInputListeners.Remove (input);
			}
		}

		float m_LastPosition;
		void OnMouseDown()
		{
			m_LastPosition = Input.mousePosition.x;
			Debug.Log ("<color=green>Mouse button pressed</color>");
		}
		void OnMouseUp()
		{
			Debug.Log ("<color=red> Mouse button exit</color>");
		}

		void OnMouseDrag()
		{
			//Debug.Log ("Dragging mouse: "+Input.mousePosition);

			float m_CurrentPosition = Input.mousePosition.x;
			float deltaX = m_CurrentPosition - m_LastPosition;


			userInputListeners.ForEach (x => x.OnMouseMoved (deltaX));
			m_LastPosition = m_CurrentPosition;

		}
	}
}
