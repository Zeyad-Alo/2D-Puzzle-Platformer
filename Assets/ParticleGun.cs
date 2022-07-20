using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGun : MonoBehaviour
{

    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule emission;
    private GameObject player;

    Vector3 mousePos;


    void OnEnable () {
        _particleSystem = gameObject.GetComponent<ParticleSystem>();
        emission = _particleSystem.emission;
        emission.enabled = false;

        player = GameObject.FindWithTag("Player");
     }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && player.GetComponent<SpriteRenderer> ().sprite.name == "alienPink_badge1")
        {
            emission.enabled = true;
        }
        else {
            emission.enabled = false;
        }
        
    }

    void FixedUpdate()
    {
        Vector2 direction = mousePos - gameObject.transform.position;
        //gameObject.transform.LookAt(gameObject.transform.position + direction);
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var Shape = _particleSystem.shape;
        Shape.rotation = new Vector3 (0,0,angle);
    }
}