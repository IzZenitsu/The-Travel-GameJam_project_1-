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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, Layer))
        {
            interactiveUI.SetActive(true);

            if (hit.collider.TryGetComponent(out IIntractable interact))
            {
                if (hit.collider.CompareTag("Objects"))
                {
                    interact.PickUp();
                    interactiveObj.text = "Pick Up";

                    
                }
                else if (hit.collider.CompareTag("Door"))
                {
                    interact.Interact();
                    interactiveObj.text = "Open Door";
                }
                else if (hit.collider.CompareTag("TV"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactiveUI.SetActive(false);
                    }
                    interact.TvToGame();
                    interactiveObj.text = "Play";
                }
            }

        }
        else 
        { 
            interactiveUI.SetActive(false);
        }
    }
}
