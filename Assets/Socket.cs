using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket : MonoBehaviour
{
    public GameObject head;              // ton objet à insérer
    private Rigidbody Rigidbody;

    public bool isDetached = false;

    private XRSocketInteractor interactor;

    

    void Start()
    {
        Rigidbody = head.GetComponent<Rigidbody>();
        interactor = GetComponent<XRSocketInteractor>();
        interactor.selectEntered.AddListener(OnObjectAttached);
       
    }

    private void OnObjectAttached(SelectEnterEventArgs args)
    {
        if (isDetached)
        {
            Debug.Log("Objet attaché: " + args.interactableObject.transform.name);

            if (args.interactableObject.transform.gameObject == head)
            {
                Debug.Log("C'est bien la head !");
                Rigidbody.isKinematic = true;
               
                StartCoroutine(DisableComponent());   
            }
        }
    }

    public IEnumerator DisableComponent()
    {
        yield return new WaitForSeconds(1);
        isDetached = false;  
    }

    
}
