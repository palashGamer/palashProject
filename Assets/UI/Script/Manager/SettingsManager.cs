using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.gamePlay;

namespace com.palash.lineZen.UI{
[RequireComponent(typeof(SettingsZone))]
	public class SettingsManager : MonoBehaviour {

		#region myZone
		SettingsZone _mZone;
		SettingsZone mZone{
			get{ 
				if (_mZone == null) {
					_mZone = GetComponent<SettingsZone> ();
				}
				return _mZone;
			}
		}
		#endregion

		#region Unity's Start Callback
		void Start()
		{
			mZone.sensitivitySlider.normalizedValue = (ItemsData.instance.horizontalSpeedMultiplier - 0.5f) / (2 - 0.5f);
			OnSensitivityChanged (mZone.sensitivitySlider.normalizedValue);

			mZone.difficultSlider.normalizedValue = (ItemsData.instance.ballAutoVertSpeedMultiplier - 5f) / (15 - 5f);
			OnDifficultyChanged (mZone.difficultSlider.normalizedValue);


		}	
		void OnEnable()
		{
			if (!PlayerPrefs.HasKey (GameConstants.SHOWTUT)) {
				mZone.tutToggle.isOn = true;
			}
			else {
				mZone.tutToggle.isOn = false;
			}
		}
		#endregion

		#region Button Callbacks
		public void OnSensitivityChanged(float value)
		{
			if (value < 0.3f)
				mZone.sensitivityHandler.color = Color.yellow;
			else if (value < 0.6f)
				mZone.sensitivityHandler.color = Color.green;
			else
				mZone.sensitivityHandler.color = Color.red;

			ItemsData.instance.horizontalSpeedMultiplier = (0.5f + (2 - 0.5f) * value);
			GameConstants.sensitivity = value;
		}
		public void OnDifficultyChanged(float value)
		{
			if (value < 0.3f)
				mZone.difficultyHandler.color = Color.yellow;
			else if (value < 0.6f)
				mZone.difficultyHandler.color = Color.green;
			else
				mZone.difficultyHandler.color = Color.red;

			ItemsData.instance.ballAutoVertSpeedMultiplier = (5 + (15f - 5f) * value);
			GameConstants.difficulty = value;
		}
		public void OnTutorialShow(bool show)
		{
			if (show)
				PlayerPrefs.DeleteKey (GameConstants.SHOWTUT);
			else
				PlayerPrefs.SetInt (GameConstants.SHOWTUT,1);
		}
		#endregion
	}
}
