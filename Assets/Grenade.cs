using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GrenadeBase GrenadeBase;
    void Start()
    {
        GrenadeBase = GetComponentInParent<GrenadeBase>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GrenadeBase != null)
        {
            Fire fire = other.GetComponent<Fire>();
            if (fire != null)
            {
                if (fire.Health > 0)
                {
                    GrenadeBase.ReduceHP(fire);
                }
            }
        }
    }
}
