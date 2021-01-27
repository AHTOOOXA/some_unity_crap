using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingSlider : MonoBehaviour 
{
	public GameObject objforfollow;
	Transform trans;
	Vector3 posformoving;
	void Start () 
	{
		trans = objforfollow.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		posformoving = new Vector3 (trans.position.x, trans.position.y - 1.1f, 0);
		gameObject.transform.position = posformoving;
	}
}
