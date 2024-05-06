using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 30f; // The speed at which the player moves
    public GameManager manager;

    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is 0

        Vector3 newPosition = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -11f, 11f);
        newPosition.y = Mathf.Clamp(newPosition.y, -11f, 11f);

        transform.position = newPosition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
        {
            Debug.Log("Collision Enter");
            manager.GameOver();
        }
    }
}