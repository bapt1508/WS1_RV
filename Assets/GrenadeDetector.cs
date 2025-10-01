using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Foam;
    private bool hasExploded = false;
    [SerializeField] private GameObject grenadeBase;

    /*void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Foam != null) Foam.SetActive(true);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (!hasExploded)
        {
            hasExploded = true;
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        // Active la mousse
        if (Foam != null) Foam.SetActive(true);

        // Attends 0.5s
        yield return new WaitForSeconds(0.5f);

        // Détruit la grenade entière (le parent de ce script)
        Destroy(grenadeBase);
    }
}
