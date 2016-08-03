using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PlayerController : Controller
{
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;

	private bool grounded = false;

	Camera playerCam;

	void Awake()
	{
		playerCam = Camera.main;

		rig = GetComponent<Rigidbody>();

		rig.freezeRotation = true;
		rig.useGravity = false;
	}

	void HandleActionClick()
	{
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit hitInfo;
			if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, 10f))
			{
				Block target;
				if (target = hitInfo.transform.GetComponent<Block>())
				{
					PlaceBlock(hitInfo.normal, target);
				}
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, 10f))
			{
				Block target;
				if (target = hitInfo.transform.GetComponent<Block>())
				{
					Destroy(target.gameObject);
				}
			}
		}
	}

	void PlaceBlock(Vector3 point, Block target)
	{
		Actor.Spawn("dirt", point + target.transform.position);
	}

	void LateUpdate()
	{
		HandleActionClick();
	}

	void FixedUpdate()
	{
		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rig.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rig.AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && Input.GetButton("Jump"))
			{
				rig.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		// We apply gravity manually for more tuning control
		rig.AddForce(new Vector3(0, -gravity * rig.mass, 0));

		grounded = false;
	}

	void OnCollisionStay()
	{
		grounded = true;
	}

	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}