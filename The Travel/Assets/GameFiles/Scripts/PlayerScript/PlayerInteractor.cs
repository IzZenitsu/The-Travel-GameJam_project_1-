using TMPro;    
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    
    public LayerMask Layer;
    public GameObject interactiveUI;
    public TextMeshProUGUI interactiveObj;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, 10, Layer) )
        {
            if (hit.collider.TryGetComponent(out IIntractable interact))
            {
                if (hit.collider.CompareTag("Objects"))
                {
                    interact.PickUp();
                }
                else if (hit.collider.CompareTag("Door"))
                {
                    interact.Interact();
                }
            }

        }
    }
}
