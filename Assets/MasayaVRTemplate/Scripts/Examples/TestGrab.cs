using UnityEngine;

public class TestGrab : MonoBehaviour, IGrabbable
{
    VRControllerGrab currentController;

    public void Update()
    {
        if (currentController != null)
        {

            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0); // Stall
            GetComponent<Rigidbody>().angularVelocity = new Vector3(100, -100, 100); // Stall
        }
    }

    public void GrabStart(VRControllerGrab controller)
    {
        Debug.Log("Grab Start");

        if(currentController != null)
        {
            if(currentController != controller)
            {
                currentController.GrabEnd();
                currentController = controller;
                ParentObject();
                GetComponent<Rigidbody>().useGravity = false;
            }
            GetComponent<Rigidbody>().sleepThreshold = 10000;
        }
        else
        {
            currentController = controller;
            ParentObject();
            GetComponent<Rigidbody>().useGravity = false; // Don't magnetise to the floor
            GetComponent<Rigidbody>().detectCollisions = false; // Stop collisions shifting the held object around
        }
    }

    void ParentObject()
    {
        transform.parent = currentController.transform;
        if (currentController == null) { GetComponent<Rigidbody>().linearVelocity += new Vector3(0, 15, 0);}
    }

    public void GrabEnd()
    {
        transform.parent = null;
        currentController.GrabGone(true, transform);

        currentController = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().detectCollisions = true;
    }
}
