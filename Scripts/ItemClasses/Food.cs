using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IPickDrop
{
	public GameObject thisitem;
	public string foodname;
	public float cookstatus = 0f;

	void Start()
	{
		thisitem = this.gameObject;
	}
	public virtual void Pick (Transform newparenttransfrom, ref GameObject parentpickeditem) //получает трансформ и поле еды
	{
		Debug.Log("Метод пик еды");
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<Rigidbody2D>().freezeRotation = true;
		transform.position = newparenttransfrom.Find("PickedItem").transform.position;
		transform.SetParent(newparenttransfrom.Find("PickedItem"));
		parentpickeditem = newparenttransfrom.Find("PickedItem").GetChild(0).gameObject;
		
		
	
		//какое-то дерьмо
/*		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<Rigidbody2D>().freezeRotation = true;
		transform.position = playertransfrom.FindChild("PickedItem").transform.position;
		transform.SetParent(playertransfrom.FindChild("PickedItem"), true);
		currentpickeditem = transform.gameObject;
*/
	}


	/*
	public virtual void Drop(ref GameObject currentpickeditem)
	{
		if (currentpickeditem.tag == "Pan")
		{
			GameObject foodforpan = gameObject;
			(currentpickeditem.GetComponent(currentpickeditem.tag) as IPickDrop).Drop(ref foodforpan);
		}
		else
		{
			currentpickeditem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			currentpickeditem.GetComponent<Rigidbody2D>().freezeRotation = false;
			currentpickeditem.GetComponent<Collider2D>().enabled = true;
			currentpickeditem.transform.SetParent(null);
			currentpickeditem = null;
			Debug.Log("Предмет игрока падает");
		} 
	}

	*/

	public virtual void Drop(ref GameObject playerspickeditem, ref GameObject finalobj)
	{
		Debug.Log("Метод дроп еды");

		if (finalobj == null)
		{
			Debug.Log("null условие");
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			GetComponent<Rigidbody2D>().freezeRotation = false;
			GetComponent<Collider2D>().enabled = true;
			transform.SetParent(null);
			playerspickeditem = null;
		}
		else
		{
			Debug.Log("не null условие");
			if (finalobj.tag == "Food")
			{
				finalobj = null;
				Drop(ref playerspickeditem, ref finalobj);
			}
			else
			{
				(finalobj.GetComponent(finalobj.tag) as IPickDrop).Drop(ref playerspickeditem, ref thisitem);
				playerspickeditem = null;
			}
		}
	}

	public virtual void Cook()
	{
		
	}
}
