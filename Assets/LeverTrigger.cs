using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.Events;

public class LeverTrigger : MonoBehaviour
{
    public GameObject OffLever;
    public GameObject OnLever;

    public GameObject wall;

    private GameObject player;

    private AudioSource OffAs;
    private AudioSource OnAs;

    bool IsOn = false;

    [Header("Events")]
	[Space]

	public UnityEvent LeverTriggerEvent;

    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        OffAs = OffLever.GetComponent<AudioSource>();
        OnAs = OnLever.GetComponent<AudioSource>();

        OffAs.mute = true;
        OnAs.mute = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (int.Parse(player.GetComponent<SpriteRenderer> ().sprite.name) < 11)
        {
            LeverTriggerEvent.Invoke();
            Debug.Log("activated");
        }
    }

    public void ToggleLever()
    {
        if (IsOn)
        {
            OffAs.Play();

            OnLever.SetActive(false);
            OffLever.SetActive(true);

            Color tempcolor = new Color(1,1,1,1);
            wall.GetComponent<Tilemap> ().color = tempcolor;
            wall.layer = LayerMask.NameToLayer("Closed");

        }
        else
        {
            OnAs.Play();
            
            OnLever.SetActive(true);
            OffLever.SetActive(false);

            Color tempcolor = new Color(1,1,1,0.2745098f);
            wall.GetComponent<Tilemap> ().color = tempcolor;
            wall.layer = LayerMask.NameToLayer("Open");

        }

        if (OnAs.mute && OffAs.mute)
        {
            OnAs.mute = !OnAs.mute;
            OffAs.mute = !OffAs.mute;
        }

        IsOn = !IsOn;
    }
}
