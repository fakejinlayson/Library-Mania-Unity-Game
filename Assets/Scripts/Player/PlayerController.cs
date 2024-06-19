using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;

	private Rigidbody2D rb;

    [SerializeField] private float timeBetweenSteps = 0.25f;
    [SerializeField] private float currTimeStep = 0;

	[SerializeField] PlayerTask playerTask;

	// Use this for initialization
	void Start () {
		// rb = GetComponent<Rigidbody2D>();
		// // Freeze rotation on Z axis so only the mouse can rotate the player. This will prevent other physics object rotating it. We can unlock this if we ever want to throw the player or similar.
		// rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		if (playerTask == null) 
		{
			playerTask = GetComponent<PlayerTask>();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		currTimeStep++;
        if (currTimeStep >= timeBetweenSteps) 
        {
            // Handle the movement in FixedUpdate as it is physics related
            HandleMovement();
            //HandleRotation();
            currTimeStep = 0;
        }
	}

	void HandleMovement() {
		Vector3 currentPosition = gameObject.transform.position;
		// A and D
		float horizontalAxisMovement = Input.GetAxisRaw("Horizontal");
		// W and S
		float verticalAxisMovement = Input.GetAxisRaw("Vertical");

        //init new movement vector
        Vector2 newMovementVector = new Vector2 (horizontalAxisMovement * 0.16f, verticalAxisMovement * 0.16f);

        // Apply the movement vector direction
		Vector3 targetPosition = gameObject.transform.position + (Vector3)newMovementVector;
		targetPosition.z = 0;
		
		if (horizontalAxisMovement == 0 && verticalAxisMovement == 0) return;

		// if (Physics2D.OverlapBox(targetPosition, new Vector2(0.08f, 0.08f), 0) == gameObject.TryGetComponent<AITask>(out AITask aiTask))
		// {
		// 	if (aiTask != null)
		// 	{
		// 		Debug.Log("AI task found");
		// 		if (aiTask.completed == true)
		// 		{
		// 			return;
		// 		}

		// 		playerTask.SetTask(aiTask.GetSection(), aiTask);
		// 		return;
		// 	}
		// }

		//check collisions
		if (Physics2D.OverlapBox(targetPosition, new Vector2(0.08f, 0.08f), 0) == null) {

			gameObject.transform.position += (Vector3)newMovementVector;	

			if (playerTask.aITask != null) {
				playerTask.aITask.HandleFollowMovement(currentPosition);
				if (playerTask.aITask.flipflop == true) {
					playerTask.RemoveAI();
				}
			}
		}

	}

	void HandleRotation() {
		Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Get the distance between the player and the mouse. This is how we build the two sides of the triangle to get the angle to rotate. Atan2 is confusing :(
		mousePositionInWorld.x = mousePositionInWorld.x - transform.position.x;
		mousePositionInWorld.y = mousePositionInWorld.y - transform.position.y;

		float angleToRotate = Mathf.Atan2(mousePositionInWorld.y, mousePositionInWorld.x) * Mathf.Rad2Deg;
		rb.rotation = angleToRotate;
	}
}