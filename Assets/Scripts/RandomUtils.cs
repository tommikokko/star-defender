using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomUtils : MonoBehaviour {

	public static int GetRandomIndex(List<float> list)
	{
		float sum = list.Sum();
		float random = Random.Range(0, sum);
		float checkSum = 0;
		for(int i = 0; i < list.Count; i++)
		{
			checkSum = checkSum + list[i];
			if(random <= checkSum) return i;
		}
		return 0;
	}
}
