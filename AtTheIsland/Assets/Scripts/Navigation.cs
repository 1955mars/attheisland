using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public GameObject player;
    public bool teleport;

    private float offsetHeight = 0.5f;
    private float moveTime = 0.2f;

    public void Move (GameObject wayPoint)
    {
        if (!teleport)
        {
            iTween.MoveTo(player,
                iTween.Hash(
                    "position", new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y + offsetHeight, wayPoint.transform.position.z),
                    "time", moveTime,
                    "easytype", "linear"
                )
            );
        } else
        {
            player.transform.position = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y + offsetHeight, wayPoint.transform.position.z);
        }

    }

}
