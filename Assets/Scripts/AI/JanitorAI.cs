using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JanitorAI : MonoBehaviour
{
    [SerializeField] private float timeBetweenSteps = 1f;
    [SerializeField] private float currTimeStep = 0;

    void Update() 
    {
		
        currTimeStep += Time.deltaTime;
        if (currTimeStep >= timeBetweenSteps) 
        {
            // Handle the movement in FixedUpdate as it is physics related
            HandleMovement();

            //HandleRotation();
            currTimeStep = 0;
        }
	}

    void HandleMovement() 
    {
        Vector3 currentPosition = gameObject.transform.position;

        List<Vector3> availablePlaces = new List<Vector3>();

        Vector3[] possiblePlaces = new Vector3[]
        {
            currentPosition + new Vector3(0, 0.16f, 0),
            currentPosition + new Vector3(0, -0.16f, 0),
            currentPosition + new Vector3(-0.16f, 0, 0),
            currentPosition + new Vector3(0.16f, 0, 0)
        };

        foreach (Vector3 place in possiblePlaces)
        {
            if (Physics2D.OverlapBox(place, new Vector2(0.08f, 0.08f), 0) == null && Physics2D.OverlapBox(place, new Vector2(0.08f, 0.08f), 0) != this.gameObject)
            {
                availablePlaces.Add(place);
            }
        }

        // if (availablePlaces.Count > 0)
        // {
        //     Destroy(this.gameObject);
        //     return;
        // }

        Vector3 targetPosition = availablePlaces[Random.Range(0, availablePlaces.Count)];
        targetPosition.z = 0;

        gameObject.transform.position = targetPosition;
    }
}
