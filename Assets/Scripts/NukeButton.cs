using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class NukeButton : MonoBehaviour {
	
	private float nukeTimer = 0;
	[SerializeField]
	private Button nukeButton;
	[SerializeField]
	private Image nukeImage;
	private float nukeTimeInterval;
	void Start()
	{
		nukeButton.interactable = false;
		nukeImage.fillAmount = 0;
		nukeTimeInterval = LevelController.Instance.GetNukeTimeInterval();
		LevelController.Instance.OnReset += StartOver;
	}
	public void OnClick()
	{
		LevelController.Instance.DoNuke();
		nukeButton.interactable = false;
	}

	void Update()
	{
		if(nukeTimer >= nukeTimeInterval)
		{
			nukeTimer = 0;
			nukeButton.interactable = true;
		}
		if(!nukeButton.interactable)
		{
			nukeTimer += Time.deltaTime;
			if(nukeTimer > nukeTimeInterval) nukeTimer = nukeTimeInterval;
			nukeImage.fillAmount = nukeTimer / nukeTimeInterval;
		}
	}

	public void StartOver()
	{
		LevelController.Instance.OnReset -= StartOver;
		Start();
	}
}
