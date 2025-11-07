using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 5;
    
    [SerializeField] private GameObject boomImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        boomImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        Debug.Log("Take damage");
        health--;
        Mathf.Clamp(health, 0f, 5f); // For some reason it doesn't clamp the value, moving forward...
        boomImage.SetActive(true);
        StartCoroutine(WaitForBoom());

        if (health <= 0)
        {
            PlayerController playerController = GetComponentInParent<PlayerController>();
            string playerName = playerController.GetPlayerName();
            Manager.Instance.EndGame(playerName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (other.gameObject == null)
            return;
        
        Debug.Log($"Collided gameobject name: {other.gameObject.name}");
        if (other.gameObject.CompareTag("Hit") )
        {
            TakeDamage();
        }
    }
    
    private IEnumerator WaitForBoom()
    {
        yield return new WaitForSeconds(3f);
        boomImage.SetActive(false);
    }
}
