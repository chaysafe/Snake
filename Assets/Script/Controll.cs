using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.Linq;


public class Controll : MonoBehaviour {

	public List<Transform> tail = new List<Transform>();

	private float speed = 0.1f;
	Vector2 vector = Vector2.up;
	Vector2 moveVector;

	public GameObject food;
	public GameObject tailPrefab;


	
	bool eat = false;

	bool vertical = false;
	bool horizontal = true;


	// Use this for initialization
	void Start () {
		InvokeRepeating("Movement", 0.3f, speed);
		SpawnFood ();


	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			vector = Vector2.right;
		} else if (Input.GetKey (KeyCode.UpArrow) && vertical) {
			horizontal = true;
			vertical = false;
			vector = Vector2.up;
		} else if (Input.GetKey (KeyCode.DownArrow) && vertical) {
			horizontal = true;
			vertical = false;
			vector = -Vector2.up;
		} else if (Input.GetKey (KeyCode.LeftArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			vector = -Vector2.right;
		}
		moveVector = vector / 3f;
	
	}

	void Movement() {
		Vector2 ta = transform.position;
		if (eat) {

			GameObject g =(GameObject)Instantiate(tailPrefab, ta,Quaternion.identity);

			tail.Insert(0, g.transform);


			eat = false;
		}
		else if (tail.Count > 0) {
			tail.Last().position = ta;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
		transform.Translate(moveVector);
	}


	void OnTriggerEnter(Collider c) {
		
		if (c.name.StartsWith("Food")) {
			eat = true;
			Destroy(c.gameObject);
			SpawnFood();
		}
		else if(c.name.StartsWith("tailPrefab"))
		{
			Destroy(c.gameObject);
			Invoke("Re",0);
		}
		else
		{

			Invoke("Re",0);
		}
	}
//	public void OnCollisionEnter(Collision other)
//	{
//		if(name=="Food"){
//		eat = true ;
//		Destroy (other.gameObject);
//		SpawnFood ();
//		}
//	}
	public void SpawnFood() {
		int x = (int)Random.Range (-8,8);
		int y = (int)Random.Range (-4, 4);
		
		Instantiate (food, new Vector2 (x, y), Quaternion.identity);
		
	}
	public void Re()
	{
		Application.LoadLevel("Snake");
	}
}
