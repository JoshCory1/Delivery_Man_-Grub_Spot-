using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float timeDestroy = .5f;
    [SerializeField] float timeEnd = 2f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
        // startReload();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up!");
            Destroy(other.gameObject, timeDestroy);
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delieverd");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
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
