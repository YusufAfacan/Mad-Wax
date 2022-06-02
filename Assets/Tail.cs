using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public float pointSpacing = 0.1f;
    public Transform snake;

    List<Vector2> points;

    LineRenderer line;
    EdgeCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();

        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }

        
    }

    void SetPoint()
    {
        if (points.Count > 1)
        {
            col.points = points.ToArray<Vector2>();
        }

        points.Add(snake.position);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, snake.position);

       
    }
}
