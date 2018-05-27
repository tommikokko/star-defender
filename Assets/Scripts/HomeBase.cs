using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : Entity {
	public void DecreaseHealth(Vector3 value)
	{
		if(shield == 0) size += value;
		if(size.x >= 9){ 
			Destroy();
			LevelController.Instance.Restart();
		}
	}	

}
