﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private Level level;
    [SerializeField]
    private GameObject homeBase;
    [HideInInspector]
    public GameObject HomeBase;
    private float timer = 0;
    private List<GameObject> enemies = new List<GameObject>();
    private List<EnemySpawner> spawners;
    private static LevelController instance;

    public static LevelController Instance
    {
        get
        {
            if (instance == null) instance = Component.FindObjectOfType<LevelController>();
            return instance;
        }
    }

    void Awake()
    {
        if (Instance != this) Destroy(this);

        Init();
    }
    
    void Init()
    {
        HomeBase = Instantiate(homeBase, transform.position, Quaternion.identity, transform);
        spawners = new List<EnemySpawner>();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<EnemySpawner>() != null) spawners.Add(child.GetComponent<EnemySpawner>());
        }
    }

    void OnDestroy()
    {
        if (Instance == this) instance = null;
    }

    int index = 0;
    void Update()
    {
        if (enemies.Count < level.MaxEnemies)
        {
            timer += Time.deltaTime;
            if (timer > level.EnemySpawnInterval)
            {
                enemies.Add(spawners[index].SpawnEnemy());
                index++;
                if (index == spawners.Count) index = 0;
                timer = 0;
            }
        }
    }
    public void DestroyEnemy(Enemy enemy)
    {
        enemies.Remove(enemy.gameObject);
    }
    public int GetEnemySize()
    {
        return level.NextEnemySize;
    }
    public float GetMaxEnemySpeed()
    {
        return level.MaxEnemySpeed;
    }
    
    /* 
    * Delegates and events for nuke and reset
    */

    public delegate void OnNukeHandler();
    public event OnNukeHandler OnNuke;
    public delegate void OnResetHandler();
    public event OnResetHandler OnReset;

    /* 
    * Restart level
    */
    public void Restart()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i]) enemies[i].GetComponent<Enemy>().Destroy();
        }
        enemies.Clear();
        spawners.Clear();
        DoReset();
        ScoreController.Instance.Reset();

        Init();
    }
    public void DoNuke()
    {
        OnNuke();
    }

    public void DoShield()
    {
        homeBase.GetComponent<Entity>().AddShield();
    }

    public float GetNukeTimeInterval()
    {
        return level.NukeTimeInterval;
    }

    public int GetMaxShield()
    {
        return level.MaxShield;
    }

    public void DoReset()
    {
        OnReset();
    }

    public int GetEnemiesToDestroyForShield()
    {
        return level.EnemiesToDestroyForShield;
    }
}
