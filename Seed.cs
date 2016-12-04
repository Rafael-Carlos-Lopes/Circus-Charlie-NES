using UnityEngine;
using System.Collections;

public class Seed: MonoBehaviour {
	[SerializeField]
	GameObject points5000;

	Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2 (0, 10);
	}

	void Update()
	{
		transform.eulerAngles += new Vector3 (0, 0, 360 * Time.deltaTime);

		if (transform.position.y < -3.7f) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Charlie")) 
		{
			Instantiate (points5000, transform.position, Quaternion.identity);
		}
	}

}
