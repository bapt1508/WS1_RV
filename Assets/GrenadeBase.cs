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
        // Récupérer le composant XRGrabInteractable
        xrGrab = GetComponent<XRGrabInteractable>();

        xrGrab.selectExited.AddListener(OnThrown);

        // S'enregistrer sur l’événement de désactivation (ex: gâchette relâchée)
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

        // Activer / désactiver le collider
        if (Detector != null) Detector.SetActive(active);
    }

    public void ReduceHP(Fire fire)
    {
        fire.Health = fire.Health * 0;

    }
}
