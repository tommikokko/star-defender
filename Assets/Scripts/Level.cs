using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField]
    private int maxEnemies = 20;
    [SerializeField]
    private float enemySpawnInterval = 0.2f;
    [SerializeField]
    private float maxEnemySpeed = 0.2f;
    [SerializeField]
    private List<float> sizeProbabilities;
    public int MaxEnemies
    {
        get
        {
            return maxEnemies;
        }
    }
    public int NextEnemySize
    {
        get
        {
            return RandomUtils.GetRandomIndex(sizeProbabilities) + 1;
        }
    }
    public float MaxEnemySpeed
    {
        get
        {
            return maxEnemySpeed;
        }
    }
    public float EnemySpawnInterval
    {
        get
        {
            return enemySpawnInterval;
        }
    }

}
