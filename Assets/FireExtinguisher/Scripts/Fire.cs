using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Tooltip("The maximum value of health")]
    [SerializeField] private float maxHealth;

    [Tooltip("How much health per secondes the fire gain when not extinguished")]
    [SerializeField] private float healthIncreasePerSec;


    [Tooltip("What scale to apply according to the health")]
    [SerializeField] private float scalePerHealth;

    [SerializeField] private float health;

    public GameObject fire;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            UpdateHealth();
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        
        
        if (health <= 0)
        {
            fire.SetActive(false);
            
            this.transform.localScale = Vector3.one * (maxHealth * scalePerHealth); 
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // TODO
        if(health <= 0)
        {
            fire.SetActive(false);
            return;
        } 
        UpdateHealth();
    }

    void UpdateHealth()
    {
        // activate/deactivate gameObject if health > 0
        if (health <= 0)
        {
            fire.SetActive(false);
            transform.localScale = Vector3.zero;

        }


        // Gain health if fire is not fully extinguished

        health += healthIncreasePerSec * Time.fixedDeltaTime;
        health = Mathf.Min(health, maxHealth);
        health = Mathf.Max(health, 0f);

        float s = Mathf.Max(0f, scalePerHealth * health);
        transform.localScale = Vector3.one * s;

    }
}
