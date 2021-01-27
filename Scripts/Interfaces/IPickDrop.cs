using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickDrop
{
	void Pick(Transform newparenttransfrom, ref GameObject parentpickeditem);
	void Drop(ref GameObject currentpickeditem, ref GameObject finalobj);
}
