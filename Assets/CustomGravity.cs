using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CostumGravity : MonoBehaviour {
	
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
	
	
	/*
	void Start () {
		GameObject[] Objects = GameObject.FindGameObjectsWithTag ("Planet");
		
		//the gravity between each couple of object is calculated
		foreach (GameObject ObjectA in Objects) 
		{
			ObjectA.rigidbody.AddForce(new Vector3(100,0,0));
		}
	}
	
	
	void ApplyGravity(Rigidbody A, Rigidbody B)
	{
		//This is how to get the distance vector between two objects.
		Vector3 dist = B.transform.position - A.transform.position; 
		float r = dist.magnitude;
		dist /= r;
		
		//This is the Newton's equation
		//G = 6.67 * 10^-11 N.m².kg^-2
		double G =  6.674f * (10 ^ -11);
		float force = ((float)G * A.mass * B.mass) / (r * r);
		
		//Then, just apply the forces
		A.AddForce (dist * force);
		B.AddForce (-dist * force);
	}
	
	void FixedUpdate () 
	{
		//Get every object 
		GameObject[] Objects = GameObject.FindGameObjectsWithTag ("Planet");
		
		//the gravity between each couple of object is calculated
		foreach (GameObject ObjectA in Objects) 
		{
			foreach (GameObject ObjectB in Objects)
			{
				//Objects must not self interact 
				if(ObjectA == ObjectB)
					continue;
				
				ApplyGravity(ObjectA.rigidbody, ObjectB.rigidbody);
			}
			
		}
	}
	*/
}

