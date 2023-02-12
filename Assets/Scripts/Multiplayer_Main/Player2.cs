//THIS SCRIPT IS FOR SNAKE MOVEMENT AND COLLISION DETECTION
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Player2 : MonoBehaviourPunCallbacks
{
    public GameObject tailPrefab; //this represents the adding blocks of tail
    public static List<GameObject> tails = new List<GameObject>();
    private Vector3 direction;
    private Vector3 lastTailPosition;
    private float snakeHeadWidth;
    private int defaultTails = 2;
    PhotonView view;
    public static bool isPlayerAlive = true;

    public delegate void foodDestroy();
    
    public static foodDestroy onFoodDestroy;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        isPlayerAlive = true;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        snakeHeadWidth = sprite.rect.width / sprite.pixelsPerUnit;
        // by default add two tails
        for (int i=0;i<defaultTails;++i)
        {
            var tail = Instantiate(tailPrefab) as GameObject;

            // disabling colliders for default tails
            tail.GetComponent<BoxCollider2D>().enabled = false;
            tail.transform.position =  new Vector3(snakeHeadWidth * (i + 1), 0, 0);
            tails.Add(tail);
        }

        direction = Vector2.right;
        InvokeRepeating("Move", 0, 0.2f);
        //Utils.instance.foodSpawn.Invoke();
    }
    void Move(){
        if (isPlayerAlive == true) 
        {
            lastTailPosition = tails[tails.Count - 1].transform.position;

        Vector3 prevPos = transform.position;
        Vector3 currentPos = prevPos + (direction * snakeHeadWidth);
        transform.position = currentPos;

        for (int i=0;i<tails.Count;++i)
        {
            var temp = prevPos;
            prevPos = tails[i].transform.position;
            tails[i].transform.position = temp;
        }
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if(view.IsMine){
                    //Keyboard controls
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(Vector3.Dot(direction, Vector3.right) >= 0)
                direction = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(Vector3.Dot(direction, Vector3.left) >= 0)
                direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (Vector3.Dot(direction, Vector3.up) >= 0)
                direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Vector3.Dot(direction, Vector3.down) >= 0)
                direction = Vector3.down;
        }

        //Touch Swipe Controls
        if (Input.touchCount > 0) {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved) {
            // Move the snake based on the touch delta position
            Vector2 touchDeltaPosition = touch.deltaPosition;
            if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y)) {
                // Horizontal swipe
                if (touchDeltaPosition.x > 0) {
                    // Right swipe
                    direction = Vector3.right;
                } else {
                    // Left swipe
                     direction = Vector3.left;
                }
            } else {
                // Vertical swipe
                if (touchDeltaPosition.y > 0) {
                    // Up swipe
                    direction = Vector3.up;
                } else {
                    // Down swipe
                    direction = Vector3.down;
                }
            }
        }
    }
}

}


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("wall")||collision.gameObject.CompareTag("Tail")){
            Utils.instance.timerPaused.Invoke();
            isPlayerAlive = false;
            foreach(GameObject tailPrefab in tails){
                Destroy(tailPrefab);
            }
            tails.Clear();
            FoodManager.foods.Clear();
            Utils.instance.gamePopup.Invoke();
            PhotonNetwork.Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            var tail = Instantiate(tailPrefab) as GameObject;
            tail.transform.position = lastTailPosition;
            tails.Add(tail);
            Utils.instance.score.Invoke();
            Destroy(collision.gameObject);
            onFoodDestroy();
            Debug.Log("Food Item Destroyed");
            //Utils.instance.foodSpawn.Invoke();
            
        }
        else if (collision.gameObject.CompareTag("Speed"))
        {
            // speedSpawn = true;
            // SpeedManager.powerupCnt--;
            // speed = 2;
            // for (int i = 0; i < SpeedManager.Sp.Count; i++)
            // {
            //     if (SpeedManager.Sp[i] == collision.gameObject)
            //     {
            //         SpeedManager.Sp.RemoveAt(i);
            //         Destroy(collision.gameObject);
            //         int j;
            //         for (j = i; j < SpeedManager.Sp.Count - 1; j++)
            //             SpeedManager.Sp[j] = SpeedManager.Sp[j + 1];
                    
            //     }
            // }
        }
    }
}

