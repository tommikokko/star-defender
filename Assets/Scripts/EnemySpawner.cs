using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]
	private GameObject enemyPrefab;
	// Use this for initialization

	public GameObject SpawnEnemy()
	{
		return Instantiate(enemyPrefab, transform.position, transform.rotation);
	}
	
    void Update() 
	{
		if(!LevelController.Instance.HomeBase) return;
        transform.RotateAround(LevelController.Instance.HomeBase.transform.position, Vector3.forward, 40);
    }	
}
