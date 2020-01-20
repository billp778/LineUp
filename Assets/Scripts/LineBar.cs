using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineBar : MonoBehaviour
{

    public Line line;
    public Image barImage;
    public int lineMax;

    public void Start()
    {
        LineDraw.lineLength = 0;
    }

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        line = new Line(lineMax);
    }

    private void Update()
    {

        line.DrawLine(LineDraw.lineLength);

        barImage.fillAmount = line.GetHealthNormalized();

    }

}


public class Line
{

    public static int LINE_MAX = 20;

    public static float lineAmount;


    public Line(int lineMax)
    {
        LINE_MAX = lineMax;
    }

    public void DrawLine(float amount)
    {

        lineAmount = amount;

    }

    public void GainLine(int amount)
    {
        lineAmount += amount;
    }
    
    public float GetHealthNormalized()
    {
        return 1f - (lineAmount / LINE_MAX);
    }

}