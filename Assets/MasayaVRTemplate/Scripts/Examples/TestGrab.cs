using UnityEngine;

public class TestGrab : MonoBehaviour, IGrabbable
{
    VRControllerGrab currentController;
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
        }
        else
        {
            currentController = controller;
            ParentObject();
            GetComponent<Rigidbody>().useGravity = false; // Don't magnetise to the floor
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0); // Stall
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0); // Stall
        }
    }

    void ParentObject()
    {
        transform.parent = currentController.transform;
    }

    public void GrabEnd()
    {
        transform.parent = null;
        currentController.GrabGone(true, transform);

        currentController = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
