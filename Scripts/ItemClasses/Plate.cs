using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Dish
{
	void Start () 
	{
		cookable = false;
		foodinside = new GameObject [1];
	}
	
	void Update () 
	{
		
	}
}
