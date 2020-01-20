using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSegment : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<float> timeLeft;


	void Start () {
		
	}
	
	void Update () {

        for (int i = 0; i < timeLeft.Count; i++)
        {
            timeLeft[i] -= Time.deltaTime;

        }

        if (timeLeft.Count > 0)
        {
            if(timeLeft[0] < 0)
            {
                float distance = Vector3.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));
                timeLeft.RemoveAt(0);

                Vector3[] linePos = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(linePos);
                var linePosList = new List<Vector3>(linePos);
                linePosList.RemoveAt(0);
                linePos = linePosList.ToArray();
                lineRenderer.SetPositions(linePos);

                var edgeColliderList = new List<Vector2>(edgeCollider.points);
                edgeColliderList.RemoveAt(0);
                edgeCollider.points = edgeColliderList.ToArray();

                LineDraw.lineLength -= distance;
                LineDraw.lineLength = System.Math.Max(LineDraw.lineLength, 0f);
            }
        }

	}
}
