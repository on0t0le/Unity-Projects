using UnityEngine;
using System.Collections;

public class PlayBattonScript : MonoBehaviour {

    public Sprite layer_green, layer_violet;

	void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layer_violet;
    }
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layer_green;
    }
    void OnMouseUpAsButton()
    {
        Application.LoadLevel("Main");
    }

}
