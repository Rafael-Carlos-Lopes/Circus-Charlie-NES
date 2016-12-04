using UnityEngine;
using System.Collections;

public class AutoDestroy: MonoBehaviour {

	void Start()
	{
	}

	void Update()
	{
		Destroy (gameObject, 0.5f);
	}

}
