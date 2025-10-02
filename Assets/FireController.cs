using com.lineact.lit.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject head;
    private XRGrabInteractable xrGrab;
    private Rigidbody headRb;

    public Socket socket;

    public GameObject FireObject;
    private Fire fireScript;
    //public Fire fireScript;

    public BaseStateMachine tiago;
    public GameObject Collisions;
    



    void Start()
    {
        headRb = head.GetComponent<Rigidbody>();
        xrGrab = head.GetComponent<XRGrabInteractable>();
        fireScript = FireObject.GetComponent<Fire>();
    }

    // Update is called once per frame
    void Update()
    {   
        if ((fireScript.Health >=1 || !socket.isDetached))
        {
            
            xrGrab.enabled = false;
            if (!socket.isDetached){
                headRb.isKinematic = true;
                tiago.enabled = true;
            }
        }
        else
        {
            xrGrab.enabled = true;
        }
    }

    public void  DetachHead()
    {
        if (socket.isDetached) { 
            return; 
        }
        tiago.enabled = false;
        FireObject.SetActive(true);
        fireScript.Health = 100;
        headRb.isKinematic = false;
        Collisions.SetActive(false);
        headRb.AddRelativeForce(new Vector3(-1,0,-0.5f) * 5f, ForceMode.Impulse);
        StartCoroutine(ReEnableCollisions());
        socket.isDetached = true;
    }

    public IEnumerator ReEnableCollisions() {
        yield return new WaitForSeconds(0.3f);
        Collisions.SetActive(true);

    }   
}
