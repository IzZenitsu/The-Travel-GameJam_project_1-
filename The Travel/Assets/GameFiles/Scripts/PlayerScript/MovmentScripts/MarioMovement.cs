using System.Xml.Serialization;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        controller.transform.position = new Vector3(-236.47f, 4.97f, -108.45f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("BlockGround"))
        {
            controller.transform.position = new Vector3(-236.47f , 4.97f , -108.45f );
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("BlockGround"))
        {
            controller.transform.position = new Vector3(-236.47f, 4.97f, -108.45f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(1);
        }
    }



}
