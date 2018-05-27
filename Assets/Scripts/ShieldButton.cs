using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour {
	private static ShieldButton instance;
	public static ShieldButton Instance {
		get {
			if (instance == null) instance = Component.FindObjectOfType<ShieldButton>();
			return instance;
		}
	}
	
	[SerializeField]
	private Button shieldButton;
	private int enemiesDestroyed = 0;
	private int enemiesToDestroy;
	[SerializeField]
	private Image shieldBackground;

	void Awake() {
		 if (Instance != this) Destroy(this);
	}
	
	// Use this for initialization
	public void OnClickShield(){
		LevelController.Instance.HomeBase.GetComponent<HomeBase>().AddShield();
		shieldButton.interactable = false;
		shieldBackground.fillAmount = 0;
	}

	void Start()
	{
		LevelController.Instance.OnReset += Start;
		enemiesToDestroy = LevelController.Instance.GetEnemiesToDestroyForShield();
		shieldButton.interactable = false;
		shieldBackground.fillAmount = 0;
	}

	public void AddEnemyDestroyed()
	{
		if(!shieldButton.interactable && !LevelController.Instance.HomeBase.GetComponent<HomeBase>().ShieldActive)
		{
			enemiesDestroyed++;
			shieldBackground.fillAmount = (float) enemiesDestroyed / (float) enemiesToDestroy;

			if(enemiesDestroyed == enemiesToDestroy)
			{
				enemiesDestroyed = 0;
				shieldButton.interactable = true;
			}
		}
	}
	
	public void StartOver()
	{
		LevelController.Instance.OnReset -= Start;
		Start();
	}

    void OnDestroy()
    {
        if (Instance == this) instance = null;
    }
}
