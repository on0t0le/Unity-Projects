using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.name = "saw";
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0f, 0f, 2f));
	
	}
}
