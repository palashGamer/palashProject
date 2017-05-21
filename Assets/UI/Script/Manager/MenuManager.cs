using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.gamePlay;

namespace com.palash.lineZen.UI
{
	[RequireComponent(typeof(MenuZone))]
	public partial class MenuManager : MonoBehaviour {

		#region myZone
		MenuZone _mZone;
		MenuZone mZone{
			get{ 
				if (_mZone == null)
					_mZone = GetComponent<MenuZone> ();

				return _mZone;
			}
		}
		#endregion

		#region public methods
		public void HandleGameLaunchTasks()
		{
			ActivateSelf (true);
			mZone.gameStatusText.text = "";
			mZone.playCntText.text = "PLAY";
			mZone.scoreBox.SetActive (false);
			mZone.playContinueButton.onClick.AddListener (delegate {
				PlayClicked();	
			});
			showScore ();
			GameManager.instance.AddUseruserGameStatus (this);
		}
		#endregion

	}

	#region Button Handlers
	public partial class MenuManager{
		void ContinueClicked()
		{
			GameManager.instance.ContinueGame ();
			mZone.playContinueButton.onClick.RemoveAllListeners ();
		}
		void PlayClicked()
		{
			GameManager.instance.StartGame ();
			mZone.playContinueButton.onClick.RemoveAllListeners ();
		}
	}
	#endregion


	#region gameStatus handlers i.e. Game Start, Pause, Over, Continue
	public partial class MenuManager : IGameStatus{

		public void OnGameStart ()
		{
			ActivateSelf (false);
		}

		public void OnGamePause ()
		{
			ActivateSelf (true);
			mZone.gameStatusText.text = "PAUSED";
			mZone.playCntText.text = "CONTINUE";

			showScore ();
			mZone.scoreBox.SetActive (true);

			mZone.playContinueButton.onClick.AddListener (delegate {
				ContinueClicked();	
			});
		}
		public void OnGameOver()
		{
			ActivateSelf (true);
			mZone.gameStatusText.text = "GAME OVER";
			mZone.playCntText.text = "PLAY";

			showScore ();
			mZone.scoreBox.SetActive (true);

			mZone.playContinueButton.onClick.AddListener (delegate {
				PlayClicked();	
			});
		}
		public void OnGameContinue ()
		{
			ActivateSelf (false);
		}

		void showScore()
		{
			mZone.currentScore.text = GameConstants.Score.ToString();
			mZone.bestScore.text = PlayerPrefs.GetInt(GameConstants.BESTSCORE,GameConstants.Score).ToString();
		}
		void ActivateSelf (bool activateStatus)
		{
			this.gameObject.SetActive (activateStatus);
		}
		#endregion
	}
}
