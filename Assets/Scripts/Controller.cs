using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -5f;
    public float maxX = -4f;
    public float minY = -3f;
    public float maxY = 2f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move(Vector2.left + Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2.left - Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Move(Vector2.right + Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2.right - Vector2.up);
        }
        ClampPosition();
    }
    private void Move(Vector2 direction)
    {
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }
        private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }
}

