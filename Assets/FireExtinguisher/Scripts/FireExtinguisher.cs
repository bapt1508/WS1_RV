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
        // Récupérer le composant XRGrabInteractable
        xrGrab = GetComponent<XRGrabInteractable>();

        // S'enregistrer sur l’événement d’activation (ex: gâchette appuyée)
        xrGrab.activated.AddListener(OnActivated);

        // S'enregistrer sur l’événement de désactivation (ex: gâchette relâchée)
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

        // Activer / désactiver le collider
        if (colliderGo != null) colliderGo.SetActive(active);
    }

    public void ReduceHP(Fire fire)
    {   
         fire.Health -= power * Time.deltaTime;
               
    }
}
