﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -20F;
	public float maximumY = 20;

	float rotationY = 0F;

	Rigidbody rig;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		if (rig) rig.freezeRotation = true;
	}

	void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		//if (axes == RotationAxes.MouseXAndY)
		//{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			//transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
		//}
		//else if (axes == RotationAxes.MouseX)
		//{
		//	//transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		//}
		//else
		//{
		//	rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		//	rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

		//	//transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		//	Camera.main.transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		//}

		//transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

		transform.localEulerAngles = new Vector3(0, rotationX, 0);
	}
}