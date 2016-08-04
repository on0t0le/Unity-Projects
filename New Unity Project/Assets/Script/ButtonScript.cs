using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Sprite play, pause;
    public bool gPlay = false;

    void OnMouseDown()
    {
        if (!gPlay)
        {
            GetComponent<SpriteRenderer>().sprite = pause;
            gPlay = true;
        }

        else
        {
            GetComponent<SpriteRenderer>().sprite = play;
            gPlay = false;
        }


    }

    void OnMouseUp()
    {
        if (gPlay)
            GetComponent<SpriteRenderer>().sprite = pause;
        if (!gPlay)
            GetComponent<SpriteRenderer>().sprite = play;
        //else ifGetComponent<SpriteRenderer>().sprite = play;
    }


}
