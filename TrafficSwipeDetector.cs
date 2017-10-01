using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSwipeDetector : MonoBehaviour {

    //public float speed = 2f;
    public float LRspeed = 3f;

    private float[] PlayerCar_x_positions = new float[6];
    
    public float maxTime = 0.5f;
    public float minSwipeDist = 5;

    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 position;
    
    // Use this for initialization
	void Start () {
        PlayerCar_x_positions[0] = -3.06f;
        PlayerCar_x_positions[1] = -1.84f;
        PlayerCar_x_positions[2] = -0.56f;
        PlayerCar_x_positions[3] = 0.6f;
        PlayerCar_x_positions[4] = 1.79f;
        PlayerCar_x_positions[5] = 3.03f;

        position = transform.position;


    }
    static int k = 2;
    // Update is called once per frame
    void Update () {
        // position.y += speed * Time.deltaTime;
       // transform.position = position;

        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
           // Touch touch2 = Input.GetTouch(2);
           // Touch touch3 = Input.GetTouch(3);
            if (touch1.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch1.position;
            }
            else if(touch1.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch1.position;

                
                    
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if(swipeTime <= maxTime && swipeDistance >= minSwipeDist)
                {
                    
                        swipe();
                }
            }
        }
	}
    
    void swipe()
    {
        Vector2 dist = endPos - startPos;
        if(Mathf.Abs(dist.x) > Mathf.Abs(dist.y))
        {
           // Debug.Log("horizontal tha ii");
            if(dist.x>0)
            {
                goright();

            }
            if (dist.x < 0)
            {
                goleft();
            }
        }
        else if (Mathf.Abs(dist.x) < Mathf.Abs(dist.y))
        {
          //   Debug.Log("Vertical tha ii to");
            if (dist.x > 0)
            {
                goright();
            }
            if (dist.x < 0)
            {
                goleft();
            }
        }
    }
    void goright()
    {
      //  Debug.Log("horizontal right");

        if (k < 5 && k >= 0)
        {
            k += 1;
            while (position.x <= PlayerCar_x_positions[k])
            {
                position.x += LRspeed * Time.deltaTime;
                
            }
            
       //     Debug.Log("K val =" + k);

        }
     //   position.y += speed * Time.deltaTime;
     //   transform.position = position;
    }

    void goleft()
    {
        Debug.Log("horizontal left");

        if (k > 0 && k <= 5)
        {
            //position.x = PlayerCar_x_positions[--k];
            k -= 1;
            while (position.x >= PlayerCar_x_positions[k])
            {
                position.x -= LRspeed * Time.deltaTime;
                
            }

        //    Debug.Log("K val =" + k);
        }
      //  position.y += speed * Time.deltaTime;
     //   transform.position = position;
    }
}
