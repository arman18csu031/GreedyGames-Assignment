using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FoodSpawner : MonoBehaviour
{
public GameObject FoodSprite;
    public GameObject player;
    private int foodCount = 1;
    private bool isOverlap=false;
    public static List<GameObject> foods = new List<GameObject>();

    public BoxCollider2D grid;
    // Start is called before the first frame update
    public void FoodInstance()
    {
        Debug.Log("Food before if");
        Debug.Log(foodCount);
        Debug.Log(Player.isPlayerAlive);
        if (foodCount < 2 && Player.isPlayerAlive==true)
        {
            Debug.Log("Food inside if");
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
                print("haha");
                for (int i = 0; i < foods.Count; i++)
                {
                    print(foods[i].transform.position);
                    print(x + " " + y);
                    if (Vector3.Distance(new Vector3(x, y, 0), foods[i].transform.position) <= 1.5f)
                    {
                        isOverlap = true;
                        Debug.Log("Cannot spawn, coinciding with another Food");
                    }
                }
            } while (isOverlap==true);
            GameObject newSprite = PhotonNetwork.Instantiate(FoodSprite.name, new Vector2(x, y), Quaternion.identity);
            Debug.Log("Food Spawned");
            foods.Add(newSprite);
            foodCount++;
        }
    }
    void Start()
    {
        //Utils.instance.foodSpawn += FoodInstance;
        InvokeRepeating("FoodInstance", 3, 3);
    }

    private void Destroyfood(){
        foodCount--;
        foods.Clear();
    }
    public void OnEnable(){
        Player2.onFoodDestroy += Destroyfood;
    }

    public void OnDisable(){
        Player2.onFoodDestroy -= Destroyfood;
    }

}
