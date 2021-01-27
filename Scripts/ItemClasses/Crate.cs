using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Table
{
	public GameObject foodforspawn;
	public int numberofblocktype;

	public override void Pick(Transform playertransfrom, ref GameObject currentpickeditem)
	{
		if (currentfood !=null)
		{
			transform.Find("PickedItem").transform.GetChild(0).transform.position = playertransfrom.Find("PickedItem").transform.position;
			transform.Find("PickedItem").transform.GetChild(0).transform.SetParent(playertransfrom.Find("PickedItem"));
			currentfood = null;
			currentpickeditem = playertransfrom.Find("PickedItem").GetChild(0).gameObject;
		}
		else
		{
			GameObject objfromcratetohands;
			Instantiate(foodforspawn);
			objfromcratetohands = GameObject.FindGameObjectWithTag("Instantiated");
			objfromcratetohands.transform.position = playertransfrom.Find("PickedItem").transform.position;
			objfromcratetohands.GetComponent<Collider2D>().enabled = false;
			objfromcratetohands.transform.SetParent(playertransfrom.Find("PickedItem"));
			objfromcratetohands.tag = "Food";
			currentpickeditem = playertransfrom.Find("PickedItem").GetChild(0).gameObject;
		}
	}
}
