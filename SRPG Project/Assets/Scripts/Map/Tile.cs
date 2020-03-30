using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private int _Xpos;
    private int _Ypos;

    public Tile(int Xpos,int Ypos){

    }

    public int Xpos{
        get { return _Xpos; }
        set { _Xpos = value; }
    }

    public int Ypos{
        get { return _Ypos; }
        set { _Ypos = value; }
    }

}
