﻿using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position,1);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
