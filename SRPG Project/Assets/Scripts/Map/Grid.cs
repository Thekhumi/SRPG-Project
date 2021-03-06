﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : Singleton<Grid>
{
    [SerializeField] int _width = 10;
    [SerializeField] int _height = 10;
    [SerializeField] float tileSize = 10.0f;
    [SerializeField] Transform origin = null;
    public Tile[,] _Tiles;
    //transform
    Vector3 _centerVector;

    protected Grid(){

    }

    void Start(){
        _centerVector = new Vector3(tileSize / 2, tileSize / 2, 0.0f);
        _Tiles = new Tile[_width, _height];
        for (int i = 0; i < _width; i++){
            for (int y = 0; y < _height; y++){
                _Tiles[i, y] = new Tile(i, y);
                _Tiles[i, y].Xpos = i;
                _Tiles[i, y].Ypos = y;
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
        rend.positionCount = (_width * 3) + 1;
        for (int i = 0; i < _width; i++){
            rend.SetPosition(0 + i * 3, GetWorldPos(i, 0));
            rend.SetPosition(1 + i * 3, GetWorldPos(i, _height));
            rend.SetPosition(2 + i * 3, GetWorldPos(i + 1, _height));
        }
        rend.SetPosition(_width * 3, GetWorldPos(_width, 0));
        int basePos = _width * 3 + 1;
        rend.positionCount += (_height * 3);
        for (int i = 0; i < _height; i++){
            rend.SetPosition(basePos + 0 + i * 3, GetWorldPos(0, i));
            rend.SetPosition(basePos + 1 + i * 3, GetWorldPos(0, i + 1));
            rend.SetPosition(basePos + 2 + i * 3, GetWorldPos(_width, i + 1));
        }
    }
    public int height{
        set { _height = value; }
        get { return _height; }
    }

    public int width
    {
        set { _width = value; }
        get { return _width; }
    }

    public Vector3 GetWorldPos(int x, int y){
        if(origin != null){
            return new Vector3(x, y) * tileSize + origin.position;
        }
        return new Vector3(x, y) * tileSize;
    }

    public Vector3 GetWorldPosCenter(int x, int y){
        if (origin != null)
        {
            return new Vector3(x, y) * tileSize + origin.position + _centerVector;
        }
        return new Vector3(x, y) * tileSize + _centerVector;
    }
}
