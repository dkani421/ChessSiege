using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileSelect : MonoBehaviour
{

    public GameObject tileHighlightPrefab;

    private GameObject tileHighlight;

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int gridPoint = Geometry.GridPoint(0, 0);
        Vector3 point = Geometry.PointFromGrid(gridPoint);
        tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
        tileHighlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;
            Vector2Int gridPoint = Geometry.GridFromPoint(point);

            tileHighlight.SetActive(true);
            tileHighlight.transform.position =
                Geometry.PointFromGrid(gridPoint);
        }
        else
        {
            tileHighlight.SetActive(false);
        }
    }
    public void EnterState()
    {
        enabled = true;
    }
}
