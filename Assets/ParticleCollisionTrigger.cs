using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParticleCollisionTrigger : MonoBehaviour
{
    public GameObject walltrigger;
    float health = 5f;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "ParticleTriggered")
        {
            health -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Toggle();
        }
    }

    void Toggle()
    {
        health = 5;
        active = !active;
        if (active)
        {
            Color tempcolor = new Color(1,1,1,1);
            walltrigger.GetComponent<Tilemap> ().color = tempcolor;
            walltrigger.layer = LayerMask.NameToLayer("Closed");
        }
        else
        {
            Color tempcolor = new Color(1,1,1,0.2745098f);
            walltrigger.GetComponent<Tilemap> ().color = tempcolor;
            walltrigger.layer = LayerMask.NameToLayer("Open");
        }
    }
}
