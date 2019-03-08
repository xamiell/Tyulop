using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5, 10)]
    [SerializeField] float moveSpeed;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private const float PADDING = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraBounds();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    /// <summary>
    /// Sets the limits of the player movement. 
    /// </summary>
    private void SetCameraBounds()
    {
        Camera camera = Camera.main;

        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + PADDING;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - PADDING;

        yMin = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).y + PADDING;
        yMax = camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - PADDING;
    }


    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newPositionX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newPositionY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newPositionX, newPositionY);
    }
}
