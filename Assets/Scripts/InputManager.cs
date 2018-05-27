using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.collider.tag == "Enemy")
				{
					Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
					enemy.DecreaseHealth();
				}
            }
        }

    }
}
