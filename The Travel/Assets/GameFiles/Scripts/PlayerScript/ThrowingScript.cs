using UnityEngine;
using UnityEngine.UI;

public class ThrowingScript : MonoBehaviour
{
    public Transform PickUpSlot;
    public GameObject throwingUi;
   
    
    void Update()
    { 
        if(PickUpSlot.childCount == 1)
        {
            
            throwingUi.SetActive(true);
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
            throwingUi.SetActive(false);
        }
    }
}
