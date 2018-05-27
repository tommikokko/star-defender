using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : Entity {
	[SerializeField]
	private GameObject shieldGO;
	
	public void DecreaseHealth(Vector3 value)
	{
		if(shield == 0)
		{
			size += value;
		}
		else
		{
			shield--;
		} 

		if(shield <= 0)
		{
			shieldGO.SetActive(false);
		}
		if(size.x >= 9){ 
			Destroy();
			LevelController.Instance.Restart();
		} 		
	}	

	void Start()
	{
		shieldGO.SetActive(false);
		maxShield = LevelController.Instance.GetMaxShield();	
	}

	public override void AddShield()
	{
		base.AddShield();
		shieldGO.SetActive(true);
	}
	
	public bool ShieldActive
	{
		get { return shieldGO.activeInHierarchy; }
	}
}
