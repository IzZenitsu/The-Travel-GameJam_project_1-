using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class MarioMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float sensitivity = 100;
    public LayerMask mask;
    public float MovmentSpeed = 10;
    public GameObject groundChecker;
    public float gravity = -9.18f;
    public float xrotation = 0;
    public bool isgrounded;
    public Vector3 velocity;
    public float jumpHeight = 3f;
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundChecker.transform.position, 0.4f, mask);
        if (isgrounded && velocity.y < 0f)
        {
            velocity.y = 0f;
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");
        

        Vector3 moveDir = - transform.right * horizontal;
        controller.Move(moveDir * MovmentSpeed * Time.deltaTime);


        #endregion

        if (!isgrounded)
        {
            velocity.y += gravity * Time.deltaTime; 
        }
        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


    }
   

    
}
