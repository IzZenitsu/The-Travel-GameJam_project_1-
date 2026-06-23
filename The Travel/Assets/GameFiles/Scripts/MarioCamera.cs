using UnityEngine;

public class MarioCamera : MonoBehaviour
{
    public GameObject Mario;
    private Vector3 position;
    public Vector3 Offset;

    void Start()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        position = new Vector3(Mario.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position + Offset;

    }
}
