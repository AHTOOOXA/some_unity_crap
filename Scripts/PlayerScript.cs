using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerScript : MonoBehaviour, IPickDrop
{
	public Transform trans;
	public float speed;
	public Rigidbody2D rig;
	public Vector3 lookatpos;
	Vector3 veclast;

	public RaycastHit2D[] hit = new RaycastHit2D[1];

	public RaycastHit2D hitfinal;
	GameObject finalobj;
	 
	Vector2 vec;
	public GameObject lastobj = null;


	public GameObject currentpickeditem;



	void Start () 
	{
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		Move();
		Raycast();
		PickDrop();
	}


	void Raycast ()
	{
		hit = Physics2D.RaycastAll (trans.position, veclast * 5);
		if (IsRaycastHitted (hit)) 
		{
			hitfinal = hit [1];
			finalobj = hitfinal.collider.gameObject;
			if (lastobj != null) lastobj.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			lastobj = finalobj;
			finalobj.GetComponent<SpriteRenderer> ().color = new Color (0.75f, 0.75f, 0.75f, 1f);

		} 
		else 
		{
			if (lastobj != null) lastobj.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			lastobj = null;
		}
	}

	bool IsRaycastHitted(RaycastHit2D[] hit)	
	{
		if (hit.Length > 1) 
		{
			return true;
		} 
		else
			finalobj = null;
			return false;
	}

	void Move ()
	{
		vec = new Vector2 (CnInputManager.GetAxis ("Horizontal"), CnInputManager.GetAxis ("Vertical"));
		if (vec.x != 0 && vec.y != 0) 
		{
			veclast = vec;
		}

		lookatpos = new Vector3 (CnInputManager.GetAxis ("Horizontal"), CnInputManager.GetAxis ("Vertical"), 0);

		rig.AddForce (vec * speed);
		
		if (vec.x != 0 || vec.y != 0) trans.rotation = Quaternion.LookRotation(Vector3.forward, lookatpos);
		/*if (vec.x != 0 && vec.y != 0)
		{
			anglerad = Mathf.Atan2 (vec.x, vec.y);
			angledeg = (180 / Mathf.PI) * anglerad;
			trans.rotation = Quaternion.Euler (0, 0, -angledeg);
		}*/
	}

	void PickDrop ()
	{	
		bool buttonpressed = CnInputManager.GetButtonDown("Pick/Drop");
		if (buttonpressed == true)
		{
			if(currentpickeditem != null)
			{
				(currentpickeditem.GetComponent(currentpickeditem.tag) as IPickDrop).Drop(ref currentpickeditem, ref finalobj);
				/*
				if (finalobj != null)
				{
					(finalobj.GetComponent(finalobj.tag) as IPickDrop).Drop(ref currentpickeditem);
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
				*/
			}
			else
			{
				if (finalobj != null)
				{
					(finalobj.GetComponent(finalobj.tag) as IPickDrop).Pick(trans, ref currentpickeditem);
				}
			}
		}	
	}
	
	

	void Use ()
	{	
		bool buttonpressed = CnInputManager.GetButtonDown("Use");
		if (buttonpressed == true)
		{
			if(finalobj != null && finalobj.GetComponent<Table>().usable == true)
			{

			}
		}
	}

	public virtual void Pick(Transform newparenttransfrom, ref GameObject parentpickeditem){}
	public virtual void Drop(ref GameObject currentpickeditem, ref GameObject finalobj){}
}
