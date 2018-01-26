using UnityEngine;
using System.Collections;

public class Shred : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		print ("Trigger");
		Destroy(col.gameObject);
	}
}

