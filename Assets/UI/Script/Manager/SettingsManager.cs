using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

	SettingsZone _mZone;
	SettingsZone mZone{
		get{ 
			if (_mZone == null) {
				_mZone = GetComponent<SettingsZone> ();
			}
			return _mZone;
		}
	}

	void Start()
	{
		mZone.sensitivitySlider.normalizedValue = (ItemsData.instance.horizontalSpeedMultiplier - 0.5f) / (2 - 0.5f);
		OnSensitivityChanged (mZone.sensitivitySlider.normalizedValue);

		mZone.difficultSlider.normalizedValue = (ItemsData.instance.ballAutoVertSpeedMultiplier - 5f) / (15 - 5f);
		OnDifficultyChanged (mZone.difficultSlider.normalizedValue);
	}
	public void OnSensitivityChanged(float value)
	{
		if (value < 0.3f)
			mZone.sensitivityHandler.color = Color.green;
		else if (value < 0.6f)
			mZone.sensitivityHandler.color = Color.yellow;
		else
			mZone.sensitivityHandler.color = Color.red;

		ItemsData.instance.horizontalSpeedMultiplier = (0.5f + (2 - 0.5f) * value);
	}
	public void OnDifficultyChanged(float value)
	{
		if (value < 0.3f)
			mZone.difficultyHandler.color = Color.green;
		else if (value < 0.6f)
			mZone.difficultyHandler.color = Color.yellow;
		else
			mZone.difficultyHandler.color = Color.red;

		ItemsData.instance.ballAutoVertSpeedMultiplier = (5 + (15f - 5f) * value);
	}
}
