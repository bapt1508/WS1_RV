using com.lineact.lit.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject head;         

    public Rigidbody headRb;
    public Socket socket;
    public GameObject FireObject;
    public Fire fireScript;
    private XRGrabInteractable xrGrab;
    public BaseStateMachine tiago;
    
    
    void Start()
    {
        xrGrab = head.GetComponent<XRGrabInteractable>();
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
        headRb.AddForce(Vector3.up * 100f, ForceMode.Force);
        head.GetComponent<BoxCollider>().enabled = true;
        socket.isDetached = true;
    }

   
}
