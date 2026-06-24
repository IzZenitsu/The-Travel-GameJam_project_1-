using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject clockInteractionUI;
    public GameObject spinUI;

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
                clockInteractionUI.SetActive(true);
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
                    spinUI.SetActive(true);
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
                    spinUI.SetActive(false);
                }

            }
            else 
            {
                clockInteractionUI.SetActive(false);
            }


        }
        else { clockInteractionUI.SetActive(false); }
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
        ClockRotationAngleCount = Random.Range(1, 4);

        if (ClockRotationAngleCount == 1)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0,0,0);
            Invoke("SceneChangeToScene2", 9f);
        }
        if (ClockRotationAngleCount == 2)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0, 0, 0);
            Invoke("SceneChangeToScene3", 9f);
        }
        if (ClockRotationAngleCount == 3)
        {
            ClockHandAnimator.SetInteger("TimeChange", ClockRotationAngleCount);
            clockHand.transform.Rotate(0, 0, 0);
            Invoke("SceneChangeToScene4", 9f);
        }
    }
    void SceneChangeToScene2()
    {
        SceneManager.LoadScene(2);
    }
    void SceneChangeToScene3()
    {
        SceneManager.LoadScene(3);
    }
    void SceneChangeToScene4()
    {
        SceneManager.LoadScene(4);
    }
}
