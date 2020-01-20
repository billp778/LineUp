using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject currentLine;
    public LineSegment lineSegement;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    public static float lineLength;
    public static bool isDrawing;
    public int i = 0;


    void Start () {
		
	}
	
	void Update () {
        //if we have line to draw
        if (Line.lineAmount < Line.LINE_MAX)
        {
            // on the frame that we click
            if (Input.GetMouseButtonDown(0))
            {
                createLine();
                isDrawing = true;
            }
            //each frame we have the button down
            if (Input.GetMouseButton(0) && isDrawing)
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempFingerPos);
                }
            }
        }
        else
        {
            //we ran out of line
            isDrawing = false;
            if (currentLine != null)
            {
                Destroy(currentLine, 3f);
            }
        }

        //on the frame we release
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            if (currentLine != null)
            {
                Destroy(currentLine, 3f);
            }
        }
    }

    void createLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        lineSegement = currentLine.GetComponent<LineSegment>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        lineSegement.timeLeft.Add(3f);
        lineSegement.timeLeft.Add(3f);
        edgeCollider.points = fingerPositions.ToArray();
        i = 0;

    }

    void UpdateLine(Vector2 newFingerPos)
    {
        
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
        lineSegement.timeLeft.Add(3f);
        if (i < i + 1)
        {
            float distance = Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i + 1));
            lineLength += distance;
            Debug.Log(lineLength);
        }
        i++;
    }


}