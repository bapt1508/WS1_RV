using UnityEngine;

public class ExtinguisherCollider : MonoBehaviour
{
    private FireExtinguisher extinguisher;

    void Start()
    {
        extinguisher = GetComponentInParent<FireExtinguisher>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (extinguisher != null)
        {
            Fire fire = other.GetComponent<Fire>();
            if (fire != null)
            {
                if (fire.Health > 0)
                {
                    extinguisher.ReduceHP(fire);
                }
            }
        }
    } 
}