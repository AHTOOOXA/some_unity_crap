using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IPickDrop
{
	public bool lighted = false;
	public bool burning = false;
	public bool usable;
	public GameObject currentfood = null;

	public virtual void Pick (Transform newparenttransfrom, ref GameObject parentpickeditem)
	{
		Debug.Log("Метод Pick стола");
		if (currentfood != null)
		{
			Debug.Log("не null условие");
			//
			
			/*
			transform.FindChild("PickedItem").transform.GetChild(0).transform.position = newparenttransfrom.FindChild("PickedItem").transform.position;
			transform.FindChild("PickedItem").transform.GetChild(0).transform.SetParent(newparenttransfrom.FindChild("PickedItem"));
			currentfood = null;
			parentpickeditem = newparenttransfrom.FindChild("PickedItem").GetChild(0).gameObject;
			*/

			//
			(currentfood.GetComponent(currentfood.tag) as IPickDrop).Pick(newparenttransfrom, ref parentpickeditem);
			currentfood = null;
		}
		else
		{
			Debug.Log("null условие");
			(newparenttransfrom.gameObject.GetComponent(newparenttransfrom.tag) as IPickDrop).Pick(transform, ref currentfood);
		}
	}

	/* 
	public virtual void Drop (ref GameObject currentpickeditem)
	{
		if (currentfood == null)
		{
			currentpickeditem.transform.position = transform.position;
			currentpickeditem.transform.SetParent(transform.FindChild("PickedItem").transform);
			currentfood = currentpickeditem;
			currentpickeditem = null;
			Debug.Log("Стол берет предмет");
		}
		else if (currentfood.tag == "Pan")
		{
			Debug.Log("Стол кладет предмет на сковороду");
			(currentfood.GetComponent(currentfood.tag) as IPickDrop).Drop(ref currentpickeditem);
		}
		else if (currentpickeditem.tag == "Pan")
		{
			(currentpickeditem.GetComponent(currentpickeditem.tag) as IPickDrop).Drop(ref currentfood);
		}
	}
	*/
	public virtual void Drop(ref GameObject playerspickeditem, ref GameObject finalobj)
	{
		Debug.Log("Метод Drop стола");
		if (currentfood == null)
		{
			Debug.Log("null условие");
			(finalobj.GetComponent(finalobj.tag) as IPickDrop).Pick(transform, ref currentfood);
			playerspickeditem = null;
		}
		else
		{
			Debug.Log("не null условие");
			//сбросить если лежит еда
			//положить в тарелку
			(currentfood.GetComponent(currentfood.tag) as IPickDrop).Drop(ref currentfood, ref currentfood);
		}
	}
}
