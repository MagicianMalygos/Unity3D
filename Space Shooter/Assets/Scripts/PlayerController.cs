using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	private Rigidbody rb;

	void Start () {
		this.rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate () {
		// 控制移动
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		// 控制不能超出边界
		this.rb.position = new Vector3 (
			Mathf.Clamp (this.rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (this.rb.position.z, boundary.zMin, boundary.zMax)
		);

		// 移动时倾斜
		this.rb.rotation = Quaternion.Euler (0.0f, 0.0f, this.rb.velocity.x * - tilt);
	}
}
