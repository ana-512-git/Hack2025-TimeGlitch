using UnityEngine;

public class CableDrag : MonoBehaviour
{
    public string wireColor;

    private LineRenderer lineRenderer;
    private bool isDragging = false, finish = false;
    private Vector3 startPos;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = false;

        startPos = transform.position;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = GetColor(wireColor);
        lineRenderer.endColor = GetColor(wireColor);
    }

    private void Update()
    {
        if(isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            lineRenderer.SetPosition(1, mousePos);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, startPos);  
    }

    private void OnMouseUp()
    {
        isDragging = false;
        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if(hit && hit.CompareTag("Socket"))
        {
            CableDrag end = hit.GetComponent<CableDrag>();
            if(end != null && end.wireColor == wireColor)
            {
                lineRenderer.SetPosition(1, end.transform.position);  
                finish = end.finish = true;
                return;
            }
        }

        lineRenderer.enabled = false;
    }

    private Color GetColor(string c)
    {
        switch (c.ToLower())
        {
            case "red": return Color.red;
            case "green": return Color.green;
            case "blue": return Color.blue;
            case "yellow": return Color.yellow;
            case "orange": return new Color(1f, 0.647f, 0f);
            case "purple": return new Color(0.5f, 0f, 0.5f);
            default: return Color.white;
        }
    }

    public bool isFinish()
    {
        return finish;
    }
}
