using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    private GameObject ReplayMenu;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ReplayMenu = GameObject.FindWithTag("ReplayMenu");
        ReplayMenu.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ReplayMenu.SetActive(true);
        var controller = player.GetComponent<CharacterController2D>();
        controller.IsInputEnabled = false;

        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
