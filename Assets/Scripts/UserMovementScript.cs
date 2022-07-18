using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovementScript : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f;

    Vector3 velocity;

    Rigidbody body;

	void Awake ()
    {
		body = GetComponent<Rigidbody>();
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        Vector2 playerInput;
	    playerInput.x = Input.GetAxis("Horizontal");
	    playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxAcceleration;

        //X axis
        if (velocity.x < desiredVelocity.x) {
			velocity.x =
				Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
		}
		else if (velocity.x > desiredVelocity.x) {
			velocity.x =
				Mathf.Max(velocity.x - maxSpeedChange, desiredVelocity.x);
		}

        //Z axis
        if (velocity.z < desiredVelocity.z) {
			velocity.z = Mathf.Min(velocity.z + maxSpeedChange, desiredVelocity.z);
		}
		else if (velocity.z > desiredVelocity.z) {
			velocity.z = Mathf.Max(velocity.z - maxSpeedChange, desiredVelocity.z);
		}

	    //transform.localPosition += (velocity * Time.deltaTime); 
        gameObject.transform.position += velocity;
    }
}
