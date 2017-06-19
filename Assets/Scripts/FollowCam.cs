﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	static public FollowCam S;
	public float easing=0.05f;
	public Vector2 minXY;
	public bool __________;
	public GameObject poi;
	public float camZ;
	// Use this for initialization
	void Awake () {
		S = this;
		camZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (poi == null)
			return;
		Vector3 destination = poi.transform.position;
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		destination = Vector3.Lerp (transform.position, destination, easing);
		destination.z = camZ;
		transform.position = destination;
		this.GetComponent<Camera>().orthographicSize = destination.y + 10;
	}
}
