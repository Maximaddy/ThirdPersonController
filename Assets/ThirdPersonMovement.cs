using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    public float turnsmoothtime = 0.1f;

    float smoothturnvelocity;

    public Transform cam;

    // Added to new system
    // Update is called once per frame
    void Update()
    {
        float xmovement = Input.GetAxisRaw("Horizontal");
        float zmovement = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xmovement, 0f, zmovement).normalized;

        
        if (direction.magnitude >= 0.1)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref smoothturnvelocity, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0, targetangle, 0) * Vector3.forward;

            controller.Move(moveDir * speed * Time.deltaTime);

            
        }
    }
}
