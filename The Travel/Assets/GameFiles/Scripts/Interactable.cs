using UnityEditor.Animations;
using UnityEngine;

public class Interactable : MonoBehaviour, IIntractable
{
    public string DisplayName;
    public GameObject Object;
    public Transform PickUpSlot;
    public Animator Dooranimator;
    public bool isdooropen;
    public GameObject MarioUI;
    public Camera camera;

    

    public void Interact()
    {
        if (isdooropen && Input.GetKeyDown(KeyCode.E))
        {
            Dooranimator.SetBool("DoorOpen", false);
            Debug.Log("Door Closed");
            isdooropen = false;
        }
        else if (!isdooropen && Input.GetKeyDown(KeyCode.E))
        {
            Dooranimator.SetBool("DoorOpen", true
                );

            Debug.Log("Door Open");
            isdooropen = true;
        }
    }


    

    public void PickUp()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if(PickUpSlot.childCount == 1)
            {
                GameObject child = PickUpSlot.GetChild(0).gameObject;
                child.GetComponent<Collider>().enabled = true;
                child.transform.SetParent(null);
                child.GetComponent<Rigidbody>().useGravity = true;
            }
            Object.GetComponent<Collider>().enabled = false;
            Object.GetComponent<Rigidbody>().useGravity = false;
            Object.transform.SetParent(PickUpSlot.transform);
            Object.transform.position = PickUpSlot.transform.position;
        }
      
    }
    public void TvToGame()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MarioUI.SetActive(true);
            camera.enabled = true;
        }
    }
}
