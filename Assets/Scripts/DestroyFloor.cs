using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloor : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor")) // Если объект не собран
        {
            FindObjectOfType<LifeManager>().LoseLife(); // Отнимаем жизнь
            Destroy(gameObject);
        }
    }
}
