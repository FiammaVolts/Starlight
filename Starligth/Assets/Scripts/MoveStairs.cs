using UnityEngine;

public class MoveStairs : MonoBehaviour
{
    public GameObject stairs;

    private int _counter;
    private Animator animator;

    private void Start()
    {
        animator = stairs.GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(_counter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_counter == 0) 
        {
            _counter++;

            if (animator != null)
                animator.SetTrigger("UP");
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (_counter == 1) 
        {
            _counter--;

            if (animator != null)
                animator.SetTrigger("DOWN");
        }  
    }
}
