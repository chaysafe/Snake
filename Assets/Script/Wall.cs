﻿using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public void OnCollisionEnter(Collision other)
	{
		Destroy (other.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
