using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveSquare : MonoBehaviour {

    Vector3 pos;
    float speed;
    private Vector3 target = new Vector3(2.18f, -2.7f, 0);
    int count=0;
    float x, y;
    

    public GameObject food;
    public GameObject legs;
    public GameObject rabbit;
    public Text score;

    private GameObject Food;
    private GameObject Button;
    private ButtonScript buttonScript;


    // Use this for initialization
    void Start () {
        
        x = -2.18f;
        y = 0.2f;
        Food = Instantiate(food, new Vector2(x, y), Quaternion.identity) as GameObject;
        //rabbit.GetComponent<Renderer>().enabled = false;
        rabbit.SetActive(false);
        score.text = "Pass "+count.ToString()+"/5";

        Button = GameObject.Find("Button");
        buttonScript = Button.GetComponent<ButtonScript>();
    }
	
	// Update is called once per frame
	void Update () {
       
        Move();        
        if (count != 5 && buttonScript.gPlay == true)
            speed = 2;
        else speed = 0;

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.x == 2.18f && target.y == -2.7f)
            target.x = -2.18f;
        else if (transform.position == target && target.x == -2.18f && target.y == -2.7f)
            target.y = 3.1f;
        else if (transform.position == target && target.x == -2.18f && target.y == 3.1f)
            target.x = 2.18f;
        else if (transform.position == target && target.x == 2.18f && target.y == 3.1f)
        {
            target.y = -2.7f;
            count++;
            score.text = "Pass "+count.ToString()+"/5";
            print(" "+ count.ToString());
        }
       
    }

   void OnMouseUpAsButton()
    {
        float dx = 0.5f;
        float dy = 0.5f;
         if (legs.transform.position.x >= GetComponent <Renderer>().transform.position.x - dx && legs.transform.position.x <= GetComponent<Renderer>().transform.position.x + dx && legs.transform.position.y >= Food.transform.position.y - dy && legs.transform.position.y <= Food.transform.position.y + dy)
        {            
            print("YO!");            
            //if(y<-2.6f && y>3)
                x = -2.18f + (Random.Range(1,6)) * 0.73f;
            //else x = -2.18f + (Random.Range(0, 2)) * 4.36f;
            if(x<-2.1f && x>2.1f)
                y = -2.7f + (Random.Range(1, 8)) * 0.73f;
            else y = -2.7f + (Random.Range(0,2)) * 5.8f;
            Destroy(Food);
            StartCoroutine(LateCall());
            Food = Instantiate(food, new Vector2(x, y), Quaternion.identity) as GameObject;

        }

    }

    IEnumerator LateCall()
    {
        rabbit.SetActive(true);
        yield return new WaitForSeconds(3);
        rabbit.SetActive(false);
    }
}
