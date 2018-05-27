using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Level
{
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private float enemySpawnInterval;
    [SerializeField]
    private float maxEnemySpeed;
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
