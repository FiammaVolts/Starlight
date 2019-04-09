using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public GameObject text;
    public GameObject fragment;
    
    void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            if(text.activeInHierarchy == true && Input.GetButtonDown("Interact"))
            {
                fragment.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerExit()
    {
        text.SetActive(false);
    }
}
