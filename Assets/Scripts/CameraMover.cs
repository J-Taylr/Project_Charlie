using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed = 2;
           float step;
    public float collisionTimer = 1;
    float timeSinceCollided;
    public Camera cam;
    public GameObject player;
    public float zOffset = -30;
    [Header("cameras")]
    
    public GameObject nextCamPos;
    bool followPlayer = false;
    bool isColliding = false;
    private void Start()
    {
        cam.transform.position = nextCamPos.transform.position;
        
    }

    private void Update()
    {
        
        step = speed * Time.deltaTime;
        if (followPlayer)
        {
            CamFollowPlayer();
        }
        else
        {
            CamToRoom();
        }

        if (isColliding)
        {
            ColliderTimer();
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding) { return; }

        isColliding = true;      
        if (other.gameObject.CompareTag("Player"))
        {

            if (followPlayer) { followPlayer = false; }
            else { followPlayer = true; }
            print(followPlayer);
        }
    }

    void ColliderTimer()
    {
        timeSinceCollided += Time.deltaTime;
        if (timeSinceCollided > collisionTimer)
        {
            isColliding = false;
            timeSinceCollided = 0;
        }
    }

    private void CamFollowPlayer()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, zOffset), step);
    }

    private void CamToRoom()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, nextCamPos.transform.position, step);
    }
} 
