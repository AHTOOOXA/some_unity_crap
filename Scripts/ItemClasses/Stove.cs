using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stove : Table
{
	public int numberofblocktype;

	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	//ОТРЕФАКТОРИТЬ
	public override void Drop(ref GameObject currentpickeditem, ref GameObject finalobj)
	{
		if (currentfood == null)
		{
			currentpickeditem.transform.position = transform.position;
			currentpickeditem.transform.SetParent(transform.Find("PickedItem").transform);
			currentfood = currentpickeditem;
			currentpickeditem = null;
			if (currentfood.tag == "Pan" /*&& eda ne prigotovlena*/)
			{
				//Cook(currentfood.transform.GetChild(0).gameObject);
				StartCoroutine(Cook(currentfood.transform.GetChild(0).GetChild(0).gameObject, currentfood));
			}
		}
		else if (currentfood.tag == "Pan")
		{
			Debug.Log("Стол кладет предмет на сковороду");
//НАДОБЫЛОКОМИТИТЬ			(currentfood.GetComponent(currentfood.tag) as IPickDrop).Drop(ref currentpickeditem);
		//	if /* (&& eda ne prigotovlena)    */
			{
				StartCoroutine(Cook(currentfood.transform.GetChild(0).GetChild(0).gameObject, currentfood));
			}
		}
		else if (currentpickeditem.tag == "Pan")
		{
//НАДОБЫЛОКОМИТИТЬ				(currentpickeditem.GetComponent(currentpickeditem.tag) as IPickDrop).Drop(ref currentfood);
		}
	}

	IEnumerator Cook (GameObject foodforcooking, GameObject dish)
	{
		/* for (float f = 0; f < 1; f += 0.005f)
		{
			Debug.Log("Альфа меняется");
			Color c = foodforcooking.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
			c.a = f;
			foodforcooking.transform.GetChild(0).GetComponent<SpriteRenderer>().color = c;
			yield return null;
		} */

		(dish.GetComponent(dish.tag) as Dish).slider.GetComponent<Slider>().fillRect.gameObject.SetActive(true);

		while (foodforcooking.GetComponent<Food>().cookstatus < 1)
		{
			foodforcooking.GetComponent<Food>().cookstatus += 0.01f;
			Debug.Log("Альфа меняется");
			Color c = foodforcooking.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
			c.a = foodforcooking.GetComponent<Food>().cookstatus;
			foodforcooking.transform.GetChild(0).GetComponent<SpriteRenderer>().color = c;
			(dish.GetComponent(dish.tag) as Dish).slider.GetComponent<Slider>().value = foodforcooking.GetComponent<Food>().cookstatus;
			yield return new WaitForSeconds(0.1f);
			//yield return null;
		}
	}
}