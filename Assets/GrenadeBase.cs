using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityEngine.XR.Interaction.Toolkit;

public class GrenadeBase : MonoBehaviour
{
    //[SerializeField] private GameObject foamGo;     // La mousse visuelle
    [SerializeField] private GameObject Detector; // Le collider de la mousse

    private bool goupille = false;
    

    private XRGrabInteractable xrGrab;

    void Start()
    {

        xrGrab = GetComponent<XRGrabInteractable>();
        xrGrab.activated.AddListener(OnActivated);
        xrGrab.selectExited.AddListener(OnThrown);

        


    }

    private void OnActivated(ActivateEventArgs args)
    {
        goupille = true;    
    }

    private void OnThrown(SelectExitEventArgs args)
    {
        if (goupille)
        {
            setActivation(true);
        }
    }

    

    private void setActivation(bool active)
    {
        
        if (Detector != null) Detector.SetActive(active);
    }

    public void ReduceHP(Fire fire)
    {
        fire.Health = fire.Health * 0;

    }
}
