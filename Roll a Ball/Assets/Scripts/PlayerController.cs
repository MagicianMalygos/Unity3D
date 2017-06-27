using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Console.WriteLine ("XXX");
	}

	// 在多帧中应用
	void Fixedupdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 move = new Vector3 (10.0f, 0.0f, 10.0f);

		// 添加力到刚体上
		rb.AddForce (move * speed);
		Console.WriteLine ("XXX");
	}
}
