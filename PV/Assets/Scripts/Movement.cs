using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speedMultiplier;
    float speed;
    [SerializeField]
    float jumpMultiplier;
    float jumpForce;
    public bool isJumping;

    Collider col;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 15f;
        jumpMultiplier = 20f;
        col = GetComponent<Collider>();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(GetComponent<Collider>().bounds.center + Vector3.down * (GetComponent<Collider>().bounds.extents.y + 0.1f), 0.1f);
    //    Gizmos.DrawSphere(col.bounds.center + new Vector3(col.bounds.extents.x - 0.1f, 0, 0) + Vector3.down * (GetComponent<Collider>().bounds.extents.y + 0.1f), 0.1f);
    //    Gizmos.DrawSphere(col.bounds.center - new Vector3(col.bounds.extents.x - 0.1f, 0, 0) + Vector3.down * (GetComponent<Collider>().bounds.extents.y + 0.1f), 0.1f);
    //}

    private bool IsGrounded()
    {   
        Vector3 rayOrigin = col.bounds.center;
        Vector3 rayOriginX = col.bounds.center + new Vector3(col.bounds.extents.x - 0.1f, 0, 0);
        Vector3 rayOriginXNegative = col.bounds.center - new Vector3(col.bounds.extents.x - 0.1f, 0, 0);
        float rayDistanceY = col.bounds.extents.y + 0.1f;

        Ray landingRay = new Ray(rayOrigin, Vector3.down);
        Ray landingRayX = new Ray(rayOriginX, Vector3.down);
        Ray landingRayXNegative = new Ray(rayOriginXNegative, Vector3.down);


        Debug.DrawRay(rayOrigin, Vector3.down * rayDistanceY, Color.red);

        return (Physics.SphereCast(landingRay, 0.1f, rayDistanceY, ~(LayerManager.layerPlayer)) | 
            Physics.SphereCast(landingRayX, 0.1f, rayDistanceY, ~(LayerManager.layerPlayer)) | 
            Physics.SphereCast(landingRayXNegative, 0.1f, rayDistanceY, ~(LayerManager.layerPlayer)));
    }

    public float Move(float input)
    {
        speed = input * speedMultiplier;

        return speed;
    }

    public void Jump()
    {
        
        if (IsGrounded() )
        {
           
            

                rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
            if (!isJumping)
            {
                isJumping = true;
            }
        }

    }
}

