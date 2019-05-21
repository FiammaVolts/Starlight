using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    void Update()
    {
        MoveAI();        
    }

    private void MoveAI()
    {    
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
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
