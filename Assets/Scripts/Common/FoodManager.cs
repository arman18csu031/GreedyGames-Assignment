using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodManager : MonoBehaviour
{
    public GameObject FoodSprite;
    public GameObject player;
    private int foodCount = 1;
    private bool isOverlap=false;
    public static List<GameObject> foods = new List<GameObject>();

    public BoxCollider2D grid;
    // Start is called before the first frame update
    void FoodInstance()
    {
        if (foodCount < 2 && Player.isPlayerAlive==true)
        {
            float x;
            float y;
            Bounds bounds = this.grid.bounds;
            do
            {
                isOverlap = false;
                x = Random.Range(bounds.min.x, bounds.max.x) * 0.5f;
                y = Random.Range(bounds.min.y, bounds.max.y) * 0.5f;
                if (Vector3.Distance(new Vector3(Mathf.Round(x), Mathf.Round(y),0), player.transform.position)<=0.5f)
                { 
                    isOverlap = true;
                    //Debug.Log("Cannot spawn, coinciding with snake");
                }

                for (int i = 0; i < Player.tails.Count; i++)
                {
                    //Debug.Log("Checking for coincidence with tail");
                    if (Vector3.Distance(new Vector3(x,y,0), Player.tails[i].transform.position)<=0.5f)
                    { 
                        isOverlap = true;
                        //Debug.Log("Cannot spawn, coinciding with tail");
                    }
                }
                for (int i = 0; i < foods.Count; i++)
                {
                    if (Vector3.Distance(new Vector3(x, y, 0), foods[i].transform.position) <= 1.5f)
                    {
                        isOverlap = true;
                        Debug.Log("Cannot spawn, coinciding with another Food");
                    }
                }
                // for (int j = 0; j < SpeedManager.Sp.Count; j++)
                // {
                //     if (Vector3.Distance(new Vector3(x, y, 0), SpeedManager.Sp[j].transform.position) <= 1.174f)
                //     {
                //         isOverlap = true;
                //         //Debug.Log("Cannot spawn, coinciding with speedPowerup");
                //     }
                // }
                // for (int j = 0; j < SpeedManager.Li.Count; j++)
                // {
                //     if (Vector3.Distance(new Vector3(x, y, 0), SpeedManager.Li[j].transform.position) <= 1.174f)
                //     {
                //         isOverlap = true;
                //         //Debug.Log("Cannot spawn, coinciding with lifePowerup");
                //     }
                // }
            } while (isOverlap==true);
            GameObject newSprite = Instantiate<GameObject>(FoodSprite);
            newSprite.transform.position = new Vector3(x, y, 0.0f);
            foods.Add(newSprite);
            foodCount++;
        }
    }
    void Start()
    {
        InvokeRepeating("FoodInstance", 3, 3);
    }

    // Update is called once per frame

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {   print("Collision");
            foodCount--;
            for(int i = 0; i < foods.Count; i++)
            {
                if (foods[i] == other.gameObject)
                {
                    foods.RemoveAt(i);
                    int j;
                    for ( j = i; j < foods.Count-1; j++)
                        foods[j] = foods[j + 1]; ;
                    
                }
            }
            Destroy(other.gameObject);
        }

    }
}

