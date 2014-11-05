using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
}
