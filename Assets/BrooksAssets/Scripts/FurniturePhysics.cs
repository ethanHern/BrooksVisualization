using Unity.VisualScripting;
using UnityEngine;

public class FurniturePhysics : MonoBehaviour
{
    public PhysicsMaterial furnitureMat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
                child.gameObject.GetComponent<BoxCollider>().material = furnitureMat;
            }
            if (child.GetComponent<Rigidbody>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
                Rigidbody rb = child.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                Vector3 old_CoM = rb.centerOfMass;
                Vector3 new_CoM = rb.centerOfMass + new Vector3(0, child.GetComponent<MeshRenderer>().bounds.size.y/2, 0);
                rb.centerOfMass = new_CoM;
            }
        }
    }

    public void triggerFurniturePhysics()
    {
        Debug.Log("The Furniture Physics function has been triggered");
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            else if (rb == null)
            {
                child.AddComponent<Rigidbody>();
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
