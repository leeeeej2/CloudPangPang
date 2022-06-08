using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    private void Update() {
        if(swipeControls.swipeUp)
        {
            desiredPosition += Vector3.up;
        }

        if(swipeControls.swipeDown)
        {
            desiredPosition += Vector3.down;
        }
        
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
    }
}
