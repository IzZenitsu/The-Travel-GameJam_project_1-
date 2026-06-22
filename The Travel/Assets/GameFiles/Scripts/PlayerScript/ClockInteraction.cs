using UnityEngine;

public class ClockInteraction : MonoBehaviour
{
    #region PrivateVariables
    private bool ischildCameraOn;
    private GameObject childCamera;
    private Renderer Playerenderer;
    private PlayerMovement playermovment;
    private ThrowingScript throwingscript;
    private int ClockRotationAngleCount;
    #endregion
    
    #region PublicVariables
    public Transform PickUpSlot;
    public Camera MainCamera;
    public Vector3 Offset;
    public GameObject player;
    public  Animator ClockHandAnimator;
    public GameObject clockHand;

    #endregion

    void Start()
    {
        Playerenderer = player.GetComponent<Renderer>();
        playermovment = player.GetComponent<PlayerMovement>();
        throwingscript = player.GetComponent<ThrowingScript>();
    }
    void Update()
    {
        #region ChangingCamera
        if (PickUpSlot.childCount == 1)
        {
            GameObject child = PickUpSlot.GetChild(0).gameObject;

            if (child.GetComponent<Interactable>().DisplayName == "Clock")
            {
                if (Input.GetKeyDown(KeyCode.G) && !ischildCameraOn)
                {
                    throwingscript.throwingUi.SetActive(false);
                    throwingscript.enabled = false;
                    Playerenderer.enabled = false;
                    playermovment.enabled = false;
                    MainCamera.enabled = false;
                    childCamera = child.transform.GetChild(0).gameObject;
                    childCamera.GetComponent<Camera>().enabled = true;
                    ischildCameraOn = true;
                }
                else if (Input.GetKeyDown(KeyCode.G) && ischildCameraOn)
                {
                    throwingscript.enabled = true;
                    throwingscript.throwingUi.SetActive(false);
                    Playerenderer.enabled = true;
                    playermovment.enabled = true;
                    MainCamera.enabled = (true);
                    ischildCameraOn = false;
                    childCamera.GetComponent<Camera>().enabled = false;
                }

            }


        }
        #endregion
        if (ischildCameraOn && Input.GetKeyDown(KeyCode.Space))
        {
            //Spin the clock
            Debug.Log("Clock spun!");
            ClockHandSpin();
        }
    }
    void ClockHandSpin()
    {
        ClockRotationAngleCount = Random.Range(0, 3);

        if (ClockRotationAngleCount == 1)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0,0,0);

        }
        if (ClockRotationAngleCount == 2)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0, 0, 0);



        }
        if (ClockRotationAngleCount == 3)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0, 0, 0);



        }
    }
}
