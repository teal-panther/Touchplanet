using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CGravity : MonoBehaviour {

	static float G = 0.01f; // adjust with try & error
	
	static List<Rigidbody> planets = new List<Rigidbody>(); private Rigidbody myRigidbody;
	
	//for testing. Set the z value to give the planet an initial speed along it's z-axis 
	public Vector3 initialForwardSpeed;
	
	public int speed;
	
	void Awake() { myRigidbody = rigidbody; myRigidbody.velocity = transform.TransformDirection(initialForwardSpeed); }
	
	void OnEnable() { planets.Add(rigidbody); }
	
	void OnDisable() { planets.Remove(rigidbody); }
	
	void FixedUpdate() { 
		
		if (tag != "Sonne")
		{
			var pos = myRigidbody.position; 
			var acc = Vector3.zero; 
			foreach(Rigidbody planet in planets) { 
				if (planet == myRigidbody) continue; 
				var direction = (planet.position - pos); 
				acc += G * (direction.normalized * planet.mass) / direction.sqrMagnitude; 
			} 
			myRigidbody.velocity += acc * Time.fixedDeltaTime;
		}
	}

}
