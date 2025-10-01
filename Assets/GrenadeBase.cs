using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrenadeBase : MonoBehaviour
{
    //[SerializeField] private GameObject foamGo;     // La mousse visuelle
    [SerializeField] private GameObject Detector; // Le collider de la mousse
    
    

    private XRGrabInteractable xrGrab;

    void Start()
    {
        // R�cup�rer le composant XRGrabInteractable
        xrGrab = GetComponent<XRGrabInteractable>();

        xrGrab.selectExited.AddListener(OnThrown);

        // S'enregistrer sur l��v�nement de d�sactivation (ex: g�chette rel�ch�e)
        /*xrGrab.deselected.AddListener(OnDeactivated);
        setActivation(false);*/


    }

    private void OnThrown(SelectExitEventArgs args)
    {
        
        setActivation(true);
    }

    

    private void setActivation(bool active)
    {
        // Afficher / cacher la mousse
        //if (foamGo != null) foamGo.SetActive(active);

        // Activer / d�sactiver le collider
        if (Detector != null) Detector.SetActive(active);
    }

    public void ReduceHP(Fire fire)
    {
        fire.Health = fire.Health * 0;

    }
}
