using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    float speed = 1;
    GameObject homeBase;
    float sizeScaler = 0.4f;

    
    void Start()
    {
        LevelController.Instance.OnNuke += DecreaseHealth;
        homeBase = LevelController.Instance.HomeBase;
        health = LevelController.Instance.GetEnemySize();
        transform.localScale = new Vector3(health * sizeScaler, health * sizeScaler, health * sizeScaler);
        size = transform.localScale;
        speed = LevelController.Instance.GetMaxEnemySpeed() / (float)health;
        growSpeed = 100;
        
        if (homeBase != null)
        { 
            transform.LookAt(homeBase.transform);
        }
    }

    public override void DecreaseHealth()
    {
        base.DecreaseHealth();
        size -= Vector3.one * sizeScaler;
        transform.localScale = size;
        Destroyed = true;
    }

    void Update()
    {
        float step = Time.deltaTime * speed;
        if (homeBase != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, homeBase.transform.position, step);
        }
        else
        {
            Destroy();
        }
    }

    public bool Destroyed = false;

    // Destroy the enemy and remove it from OnNuke delegate
    public override void Destroy()
    {
        Destroyed = true;
        LevelController.Instance.OnNuke -= DecreaseHealth;
        ShieldButton.Instance.AddEnemyDestroyed();
        base.Destroy();
    }

    void OnDestroy()
    {
        if(LevelController.Instance) LevelController.Instance.DestroyEnemy(this);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!homeBase.GetComponent<HomeBase>().Growing)
        {
            homeBase.GetComponent<HomeBase>().DecreaseHealth(size);
        }
        Destroy();
    }
}
