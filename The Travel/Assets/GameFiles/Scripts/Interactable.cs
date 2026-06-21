using UnityEngine;

public class Interactable : MonoBehaviour, IIntractable
{
    public string DisplayName;
    public GameObject Object;
    public Transform PickUpSlot;
    public Animator Dooranimator;
    public bool isdooropen;

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
            Dooranimator.SetBool("DoorOpen", true);

            Debug.Log("Door Open");
            isdooropen = true;
        }
    }


    

    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Object);
            GameObject a = Instantiate(Object, PickUpSlot.position ,Quaternion.identity);
            a.GetComponent<Collider>().enabled = false;
            a.GetComponent<Rigidbody>().useGravity = false;
            a.transform.SetParent(PickUpSlot.transform);
        }
      
    }
}
