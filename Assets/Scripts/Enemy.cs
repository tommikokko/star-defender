using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    float speed = 1;
    GameObject homeBase;
    public float sizeScaler = 0.2f;

    public override void DecreaseHealth()
    {
        //base.DecreaseHealth();
        size -= Vector3.one * sizeScaler;
        transform.localScale = size;
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

    void OnDestroy()
    {
        LevelController.Instance.DestroyEnemy(this);
    }

    void Start()
    {
        homeBase = LevelController.Instance.HomeBase;
        health = LevelController.Instance.GetEnemySize();
        transform.localScale = new Vector3(health * sizeScaler, health * sizeScaler, health * sizeScaler);
        size = transform.localScale;
        speed = LevelController.Instance.GetMaxEnemySpeed() / (float)health;
        Debug.Log("Speed: " + speed + " LevelController.Instance.GetMaxEnemySpeed()" + LevelController.Instance.GetMaxEnemySpeed());
        growSpeed = 100;
        if (homeBase != null) transform.LookAt(homeBase.transform);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(transform.position + " " + size + " " + health);
        if (!homeBase.GetComponent<HomeBase>().Growing)
        {
            homeBase.GetComponent<HomeBase>().DecreaseHealth(size);
        }
        Destroy();
    }
}
