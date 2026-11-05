using UnityEngine;

public class SyncPlayerMovement : MonoBehaviour
{

    public Transform trackingTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (trackingTransform != null)
        {
            transform.position = trackingTransform.position;
        }
    }
}
