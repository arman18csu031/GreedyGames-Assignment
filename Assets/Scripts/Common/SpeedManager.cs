using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public GameObject speedPrefab;
    public static int powerupCnt = 1;
    public bool isOver;
    public GameObject snakehead;
    public static List<GameObject> Sp = new List<GameObject>();
    void Start()
    {
        InvokeRepeating("Spawn", 10, 10);
    }
    void Spawn()
    {
        if (powerupCnt < 3 && Player.isPlayerAlive == true)
        {
            int i = Random.Range(1, 5);
            if (i == 1 || i == 3)
            {
                {
                    float x;
                    float y;
                    do
                    {
                        isOver = false;
                        x = Random.Range(-8.6f, 8.7f) * 0.5f;
                        y = Random.Range(-3.5f, 5.3f) * 0.5f;
                        if (Vector3.Distance(new Vector3(x, y, 0), snakehead.transform.position) <= 0.5f)
                        {
                            isOver = true;
                            //Debug.Log("Cannot spawn, coinciding with snake");
                        }

                        for (int j = 0; j < Player.tails.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), Player.tails[j].transform.position) <= 0.5f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with tail");
                            }
                        }
                        for (int j = 0; j < FoodManager.foods.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), FoodManager.foods[j].transform.position) <= 1.5f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with another food");
                            }
                        }
                        for (int j = 0; j < Sp.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), Sp[j].transform.position) <= 0.5f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with speedPowerup");
                            }
                        }
                        
                    } while (isOver == true);
                    GameObject newSprite = Instantiate<GameObject>(speedPrefab);
                    newSprite.transform.position = new Vector3(x, y, 0.0f);
                    Sp.Add(newSprite);
                    powerupCnt++;
                }
            }
        }
    }
}
