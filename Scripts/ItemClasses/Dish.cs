using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour, IPickDrop
{
	public GameObject slider;

	public GameObject foodforadding;

	public GameObject [] foodinside;
	public GameObject [] foodabletobestored;
	public bool cookable;

	public int ablecellsamount;
	public int currentstoredfoodamount = 0;

	void Start ()
	{
		foodinside = new GameObject [ablecellsamount];
	}

	public virtual void Pick (Transform newparenttransfrom, ref GameObject parentpickeditem) //получает трансформ и поле еды игрока после фильтрации столом +++ просто от игрока
	{	
		Debug.Log("Метод Pick посуды");
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<Rigidbody2D>().freezeRotation = true;
		transform.position = newparenttransfrom.Find("PickedItem").transform.position;
		transform.SetParent(newparenttransfrom.Find("PickedItem"));
		parentpickeditem = newparenttransfrom.Find("PickedItem").GetChild(0).gameObject;

		//сделать взаимодействие тарелок с тарелками и другой посудой
	}

	/*
	public virtual void Drop (ref GameObject currentpickeditem)
	{
		if (currentstoredfoodamount < ablecellsamount)
		{
			currentpickeditem.GetComponent<Collider2D>().enabled = false;
			currentpickeditem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			currentpickeditem.GetComponent<Rigidbody2D>().freezeRotation = true;
			currentpickeditem.transform.position = transform.position;
			currentpickeditem.transform.SetParent(transform.FindChild("PickedItem").transform);
			foodinside[currentstoredfoodamount] = currentpickeditem;
			currentpickeditem = null;
			currentstoredfoodamount ++;
			Debug.Log("Тарлелка берет предмет из рук игрока");
		}
	}
	*/
	
	public virtual void Drop (ref GameObject playerspickeditem, ref GameObject finalobj)  //еда игрока и стол
	{
		Debug.Log("Метод Drop посуды");
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
			if (currentstoredfoodamount < ablecellsamount)
			{
				//playerspickeditem = null;
		//		if (finalobj.tag == "Table")
				(finalobj.GetComponent(finalobj.tag) as IPickDrop).Pick(transform, ref foodforadding);
				currentstoredfoodamount ++;
			}
			else
			{
				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				GetComponent<Rigidbody2D>().freezeRotation = false;
				GetComponent<Collider2D>().enabled = true;
				transform.SetParent(null);
				playerspickeditem = null;
			}
		}
	}

	public virtual void Cook()
	{
		
	}
}