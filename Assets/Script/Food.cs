using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {


	public void OnCollisionEnter(Collision other)
	{
		Destroy (gameObject);
	}
}
