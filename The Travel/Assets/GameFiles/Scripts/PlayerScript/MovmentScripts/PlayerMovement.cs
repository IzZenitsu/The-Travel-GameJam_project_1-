using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera camera;
    public float sensitivity =  100;
    public LayerMask mask;
    public float MovmentSpeed = 10;
    public GameObject groundChecker;
    public float gravity = -9.18f;
    public float xrotation = 0;
    public bool isgrounded;
    public Vector3 velocity;
    public float jumpHeight = 3f;
    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update() 
    {

        isgrounded = Physics.CheckSphere(groundChecker.transform.position,0.4f, mask);
        if(isgrounded && velocity.y < 0f)
        {
            velocity.y = 0f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #region camera

        float mouseY = Input.GetAxis("Mouse Y") * 90 * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * 90 * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        camera.transform.localRotation = Quaternion.Euler(xrotation,0,0);
        transform.Rotate(0,mouseX,0);

        #endregion

        #region Movement

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveDir = transform.forward * vertical + transform.right * horizontal;
        controller.Move(moveDir * MovmentSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (!isgrounded)
        {
            MovmentSpeed = 20f;
        }
        if (isgrounded)
        {
            MovmentSpeed = 30f;
        }

        #endregion




    }
    void FixedUpdate()
    {
       
    }

}
