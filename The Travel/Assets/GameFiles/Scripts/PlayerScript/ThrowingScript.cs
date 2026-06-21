using UnityEngine;

public class ThrowingScript : MonoBehaviour
{
    public Transform PickUpSlot;
    void Update()
    { 
        if(PickUpSlot.childCount == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject child = PickUpSlot.GetChild(0).gameObject;
                child.GetComponent<Collider>().enabled = true;
                child.transform.SetParent(null);
                child.GetComponent<Rigidbody>().useGravity = true;              
            }
        }
    }
}
