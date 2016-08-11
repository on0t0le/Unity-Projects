using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform target;

	// Use this for initialization
	void Start () {

        target = GameObject.Find("Hero").transform;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(target.position.x, target.position.y, target.position.z-5);
	
	}
}
