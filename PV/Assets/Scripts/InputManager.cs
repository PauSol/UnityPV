using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    int frame = 0;
    float jumpingCooldown = 0f;
    void Update()
    {
        if (Input.GetButton("Jump") && frame % 5 == 0 /*jumpingCooldown % 0.16f == 0f*/)
            movement.Jump();

        frame++;
        jumpingCooldown += Time.deltaTime;

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
        else if (rb.velocity.x > 0.1f)
            rb.velocity = new Vector3(rb.velocity.x - 0.2f, rb.velocity.y, rb.velocity.z);
        else if (rb.velocity.x < - 0.1f)
            rb.velocity = new Vector3(rb.velocity.x + 0.2f, rb.velocity.y, rb.velocity.z);
        else if ((rb.velocity.x > 0.1f) && (rb.velocity.x < -0.1f))
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);

        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
     
    }


}
