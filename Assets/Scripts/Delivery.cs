using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    [SerializeField] float timeDestroy = .5f;
    [SerializeField] float timeEnd = 2f;
    bool hasPackage = false;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
        // Destroy(gameObject);
        startReload();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package picked up!");
            Destroy(other.gameObject, timeDestroy);
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delieverd");
            hasPackage = false;
        }
        
    }
    void startReload()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Driver>().enabled = false;
        Invoke("Reloadlevel", timeEnd);
    }
    void Reloadlevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        }
}
