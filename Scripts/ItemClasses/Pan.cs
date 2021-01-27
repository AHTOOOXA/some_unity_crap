using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : Dish, IPickDrop
{
	void Start ()
	{
		cookable = true;
		foodinside = new GameObject [1];
		//начать использовать массив
	}

	public override void Pick (Transform playertransfrom, ref GameObject currentpickeditem) //получает трансформ и поле еды игрока после фильтрации столом +++ просто от игрока
	{	
		Debug.Log("Метод Pick у сковороды");
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<Rigidbody2D>().freezeRotation = true;
		transform.position = playertransfrom.Find("PickedItem").transform.position;
		transform.SetParent(playertransfrom.Find("PickedItem"));
		currentpickeditem = playertransfrom.Find("PickedItem").GetChild(0).gameObject;
		Debug.Log("Cковорода берется в руки игроку");
		//
		/*
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<Rigidbody2D>().freezeRotation = true;
		transform.position = playertransfrom.FindChild("PickedItem").transform.position;
		transform.SetParent(playertransfrom.FindChild("PickedItem"), true);
		currentpickeditem = transform.gameObject;
		*/
	}

	public override void Drop(ref GameObject currentpickeditem, ref GameObject finalobj)
	{
		base.Drop (ref currentpickeditem, ref finalobj);
	}	

	public virtual void Cook()
	{
		
	}

	

	
	
	
	
	
	
	//старый метод

/*	public virtual void Drop(ref GameObject currentpickeditem)
	{
		//
	//	if (this.gameObject != currentpickeditem)
	//	{
			currentpickeditem.GetComponent<Collider2D>().enabled = false;
			currentpickeditem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			currentpickeditem.GetComponent<Rigidbody2D>().freezeRotation = true;
			currentpickeditem.transform.position = transform.position;
			currentpickeditem.transform.SetParent(transform.FindChild("PickedItem").transform);
			foodonthepan = currentpickeditem;
			currentpickeditem = null;
			// Сковорода берет предмет из ук игрока если она finalobj
			Debug.Log("Cковорода берет предмет из рук игрока");
//		}
	/*	else
		{
			currentpickeditem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			currentpickeditem.GetComponent<Rigidbody2D>().freezeRotation = false;
			currentpickeditem.GetComponent<Collider2D>().enabled = true;
			currentpickeditem.transform.SetParent(null);
			currentpickeditem = null;
			Debug.Log("Cковорода падает");        */
			// Сковорода падает
	//	}
																//}
}
