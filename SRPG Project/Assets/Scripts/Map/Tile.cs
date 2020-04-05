using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public struct TilePosition{
        public int Xpos;
        public int Ypos;
    }
    private TilePosition _pos; 

    public Tile(int Xpos,int Ypos){
        _pos.Xpos = Xpos;
        _pos.Ypos = Ypos;
    }

    public int Xpos{
        get { return _pos.Xpos; }
        set { _pos.Xpos = value; }
    }

    public int Ypos{
        get { return _pos.Ypos; }
        set { _pos.Ypos = value; }
    }

}
