using UnityEngine;

public class Interactable : MonoBehaviour, IIntractable
{
    public string DisplayName;
    public GameObject Object;
    public Transform PickUpSlot;
    public void Interact()
    {
        throw new System.NotImplementedException();
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
