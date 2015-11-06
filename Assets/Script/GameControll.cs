using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameControll : MonoBehaviour {
	public GameObject food;

	// Use this for initialization
	void Start () {
		SpawnFood ();
	
	}

	public void SpawnFood() {
		int x = (int)Random.Range (-9,9);
		int y = (int)Random.Range (-5, 5);
		
		Instantiate (food, new Vector2 (x, y), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
