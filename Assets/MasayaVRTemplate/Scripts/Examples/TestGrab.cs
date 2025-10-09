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
            GetComponent<Rigidbody>().useGravity = false;
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
