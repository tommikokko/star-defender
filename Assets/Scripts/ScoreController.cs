using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	private static ScoreController instance;
	public static ScoreController Instance {
		get {
			if (instance == null) instance = Component.FindObjectOfType<ScoreController>();
			return instance;
		}
	}
	
	[SerializeField]
    Text scoreText;
	[SerializeField]
	Text highScoreText;

    private int baseScore = 0;
	private int highScore = 0;
	void Awake() {
		if (Instance != this) Destroy(this);
		highScore = PlayerPrefs.GetInt("Score");
		highScoreText.text = "High Score: " + highScore;
	}
	public void AddScore()
    {
        baseScore++;
		scoreText.text = "Score: " + baseScore;
		
		if(baseScore > highScore)
		{ 
			highScore = baseScore;
			highScoreText.text = "High Score: " + highScore;
			PlayerPrefs.SetInt("Score", highScore);
		}
    }

	public void Reset()
	{
		baseScore = 0;
		scoreText.text = "Score: " + baseScore;
	}
	
}
