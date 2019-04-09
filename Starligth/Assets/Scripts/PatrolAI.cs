using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        MoveAI();        
    }

    private void MoveAI()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector3.down, 2f);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
