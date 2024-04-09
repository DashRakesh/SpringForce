using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suspension : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffeness;

    private float minLength;
    private float maxLength;
    private float springLength;
    private float springForce;
    

    private Vector3 suspensionForce;

    [Header("Coir")]
    public float coirRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        minLength = restLength - springTravel;
        maxLength = restLength + springTravel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + coirRadius))
            {
                springLength = hit.distance - coirRadius;
                springForce = springStiffeness * (restLength - springLength);
                suspensionForce = springForce * -transform.up;
                rb.AddForceAtPosition(suspensionForce, hit.point);
            }
        }
    }
}
