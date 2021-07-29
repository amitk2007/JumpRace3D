using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Not using normal animaiton because it has to be reletive to the stage rotation and not the global position
/// </summary>
public class MovingStageAnimation : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float speed;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Put the floating movement in the Update function:

        transform.position = transform.right.normalized * amplitude * Mathf.Sin(speed * Time.time) + startPos;
    }
}
