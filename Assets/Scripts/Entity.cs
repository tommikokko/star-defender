using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected int health = 20;
    protected int shield = 0;
    protected int maxShield;
    protected float growSpeed = 0.4f;
	protected Vector3 size = Vector3.one;    

    public bool Growing
    {
        get
        {
            return transform.localScale != size;
        }
    }

    public virtual void AddShield()
    {
        shield = maxShield;
    }

    public virtual void DecreaseHealth()
    {
        if (shield > 0)
        {
            shield--;
        }
        else
        {
            health--;
        }

        if (health <= 0) Destroy();
    }

    public virtual void Destroy() { 
        Destroy(gameObject);
    }
	protected virtual void FixedUpdate () 
    {
		if(Growing)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, size, growSpeed);
        }
	}    
}
