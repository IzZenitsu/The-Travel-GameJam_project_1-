using UnityEngine;
using UnityEngine.UI;

public class ThrowingScript : MonoBehaviour
{
    public Transform PickUpSlot;
    public GameObject FBackground;
    
    void Update()
    { 
        if(PickUpSlot.childCount == 1)
        {
            FBackground.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject child = PickUpSlot.GetChild(0).gameObject;
                child.GetComponent<Collider>().enabled = true;
                child.transform.SetParent(null);
                child.GetComponent<Rigidbody>().useGravity = true;              
            }
        }
        else
        {
            FBackground.SetActive(false);
        }
    }
}
