using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] int width = 10;
    [SerializeField] int height = 10;
    [SerializeField] float tileSize = 10.0f;
    [SerializeField] Transform origin = null;
    public Tile[,] _Tiles;
    void Start(){
        _Tiles = new Tile[width, height];
        for (int i = 0; i < width; i++){
            for (int y = 0; y < height; y++){
                _Tiles[i, y] = new Tile(i, y);
                //Debug.DrawLine(GetWorldPos(i, y), GetWorldPos(i + 1, y), Color.gray, 100.0f);
                //Debug.DrawLine(GetWorldPos(i, y), GetWorldPos(i, y + 1), Color.gray, 100.0f);
            }
        }
        //Debug.DrawLine(GetWorldPos(0, height), GetWorldPos(width, height), Color.gray, Mathf.Infinity);
        //Debug.DrawLine(GetWorldPos(width, 0), GetWorldPos(width, height), Color.gray, Mathf.Infinity);
        DrawGrid();
    }

    void Update()
    {
        
    }

    void DrawGrid(){
        LineRenderer rend =  GetComponent<LineRenderer>();
        rend.positionCount = (width * 3) + 1;
        for (int i = 0; i < width; i++){
            rend.SetPosition(0 + i * 3, GetWorldPos(i, 0));
            rend.SetPosition(1 + i * 3, GetWorldPos(i, height));
            rend.SetPosition(2 + i * 3, GetWorldPos(i + 1, height));
        }
        rend.SetPosition(width * 3, GetWorldPos(width, 0));
        int basePos = width * 3 + 1;
        rend.positionCount += (height * 3);
        for (int i = 0; i < height; i++){
            rend.SetPosition(basePos + 0 + i * 3, GetWorldPos(0, i));
            rend.SetPosition(basePos + 1 + i * 3, GetWorldPos(0, i + 1));
            rend.SetPosition(basePos + 2 + i * 3, GetWorldPos(width, i + 1));
        }
    }

    private Vector3 GetWorldPos(int x, int y){
        if(origin != null){
            return new Vector3(x, y) * tileSize + origin.position;
        }
        return new Vector3(x, y) * tileSize;
    }
}
