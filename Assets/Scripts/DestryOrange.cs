using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DestryOrange : MonoBehaviour
{
    public float orangeSpeed = 5f;
    private Score scoreManager;
    private Rigidbody2D rb;
    public int points = 10;

    // ���� ��� ��������, ������ �� ������
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
        if (other.CompareTag("Basket"))
        {
            // ���� ������ ����������, ���������� ����
            
            FindObjectOfType<ScoreManager>().AddScore(points); // ����������� ����
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor")) // ���� ������ �� ������
        {
            FindObjectOfType<LifeManager>().LoseLife(); // �������� �����
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        orangeSpeed = newSpeed;
    }
}