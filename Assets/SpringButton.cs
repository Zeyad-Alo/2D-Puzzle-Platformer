using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButton : MonoBehaviour
{
    public Sprite[] spriteArray;
    public GameObject player;

    float initpos;
    float currentpos;
    bool activated = true;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        initpos = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentpos = gameObject.transform.position.x;
        ToggleButton();
    }

    void ToggleButton()
    {
        if (Mathf.Abs(currentpos - initpos) > 0.5f && activated)
        {
            Color tempcolor = new Color(0.3798505f,0.8301887f,0.4817246f,1);
            var sr = gameObject.GetComponent<SpriteRenderer> ();
            sr.color = tempcolor;
            activated = false;
            count += 1;

            player.GetComponent<SpriteRenderer> ().sprite = spriteArray[count % spriteArray.Length];
            Debug.Log(player.GetComponent<SpriteRenderer> ().sprite);
        }
        else if (Mathf.Abs(currentpos - initpos) < 0.5f && !activated)
        {
            Color tempcolor = new Color(1,1,1,1);
            gameObject.GetComponent<SpriteRenderer> ().color = tempcolor;
            activated = true;
        }
    }
}
