using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class ParticleCollisionTrigger : MonoBehaviour
{
    public GameObject walltrigger;
    float health = 10f;
    bool active = true;

    private TextMeshProUGUI Tag;

    // Start is called before the first frame update
    void Start()
    {
        GameObject t = GameObject.FindWithTag("HealthTag");
        Tag = t.GetComponent<TextMeshProUGUI>();
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "ParticleTriggered")
        {
            health -= 1;
            Tag.SetText(health.ToString());
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
        health = 10f;
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
