using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class follow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed*Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
