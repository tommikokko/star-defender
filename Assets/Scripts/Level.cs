using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
*   Level structure.
*/
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
    [SerializeField]
    private float nukeTimeInterval;
    [SerializeField]
    private int maxShield;
    [SerializeField]
    private int enemiesToDestroyForShield;
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

    public float NukeTimeInterval
    {
        get 
        { 
            return nukeTimeInterval;
        }
    }
    public int MaxShield
    {
        get 
        { 
            return maxShield;
        }
    }    
    public int EnemiesToDestroyForShield
    {
        get 
        { 
            return enemiesToDestroyForShield;
        }
    }        

}
