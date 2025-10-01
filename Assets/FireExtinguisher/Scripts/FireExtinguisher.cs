using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private GameObject foamGo;     // La mousse visuelle
    [SerializeField] private GameObject colliderGo; // Le collider de la mousse
    [Tooltip("Number of health points per second extinguished from a Fire")]
    public float power = 10f;

    private XRGrabInteractable xrGrab;

    void Start()
    {
        // R�cup�rer le composant XRGrabInteractable
        xrGrab = GetComponent<XRGrabInteractable>();

        // S'enregistrer sur l��v�nement d�activation (ex: g�chette appuy�e)
        xrGrab.activated.AddListener(OnActivated);

        // S'enregistrer sur l��v�nement de d�sactivation (ex: g�chette rel�ch�e)
        xrGrab.deactivated.AddListener(OnDeactivated);
        setActivation(false);

        
    }

    private void OnActivated(ActivateEventArgs args)
    {
        setActivation(true);
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        setActivation(false);
    }

    private void setActivation(bool active)
    {
        // Afficher / cacher la mousse
        if (foamGo != null) foamGo.SetActive(active);

        // Activer / d�sactiver le collider
        if (colliderGo != null) colliderGo.SetActive(active);
    }

    public void ReduceHP(Fire fire)
    {   
         fire.Health -= power * Time.deltaTime;
               
    }
}
