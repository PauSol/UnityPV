using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Movement movement;
    Rigidbody rb;
    Renderer rend;

    void Start()
    {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
            movement.Jump();

        if (Input.GetButtonDown("ChangeColor"))
        {
            float input = Input.GetAxis("ChangeColor");
            rend.material.color = ColorManager.ChangeColor(input);
            gameObject.layer = LayerManager.ChangeLayer(input);
        }

        if (Input.GetButtonDown("ChangeDimension") && DimensionManager.canChangeDimension)
        {
            gameObject.layer = DimensionManager.ChangeDimension();
            rend.material.color = (gameObject.layer == 9) ? ColorManager.changeToRed() : ColorManager.changeToBlack();
        }

        if (Input.GetButton("Horizontal"))
            rb.velocity = new Vector3(movement.Move(Input.GetAxis("Horizontal")), rb.velocity.y, rb.velocity.z);

        Debug.Log(DimensionManager.canChangeDimension);

    }


}
