using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeverTrigger : MonoBehaviour
{
    public GameObject OffLever;
    public GameObject OnLever;

    public GameObject wall;

    private GameObject player;

    bool IsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        OnLever.SetActive(false);

        player = GameObject.FindWithTag("Player");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<SpriteRenderer> ().sprite.name == "alienYellow_badge1")
        {
            ToggleLever();
            Debug.Log("activated");
        }
    }

    void ToggleLever()
    {
        if (IsOn)
        {
            OnLever.SetActive(false);
            OffLever.SetActive(true);

            Color tempcolor = new Color(1,1,1,1);
            wall.GetComponent<Tilemap> ().color = tempcolor;
            wall.layer = LayerMask.NameToLayer("Closed");
        }
        else
        {
            OnLever.SetActive(true);
            OffLever.SetActive(false);

            Color tempcolor = new Color(1,1,1,0.2745098f);
            wall.GetComponent<Tilemap> ().color = tempcolor;
            wall.layer = LayerMask.NameToLayer("Open");
        }

        IsOn = !IsOn;
    }
}
