using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navy : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;

    [Range(5, 20)]
    [SerializeField] float speedMovement;

    private int moveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = wayPoints[moveCount].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAnim();
    }

    private void OrbitAnim()
    {
        if (moveCount <= wayPoints.Count)
        {
            var targetPosition = wayPoints[moveCount].transform.position;
            var newPosition = speedMovement * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, newPosition);

            if (targetPosition == transform.position)
            {
                moveCount++;
            }
        }

        if(moveCount >= wayPoints.Count)
        {
            moveCount = 0;
        }
    }
}
