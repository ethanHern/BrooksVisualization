using UnityEngine;

public class PitEvent : MonoBehaviour
{
    public Transform target;

    public Transform floor;

    public FurniturePhysics furnitureScript;
    public float speed = 2.0f;


    private bool pit_event_trigger = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pit_event_trigger == true && target != null)
        {
            float step = speed * Time.deltaTime;

            floor.position = Vector3.MoveTowards(floor.position, target.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && pit_event_trigger == false)
        {
            pit_event_trigger = true;
            furnitureScript.triggerFurniturePhysics();
        }
    }
}
