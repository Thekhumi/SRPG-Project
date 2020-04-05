using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    Tile.TilePosition _pos;

    void Start(){
        _pos.Xpos = 0;
        _pos.Ypos = 0;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            if(checkLimits(1, 0)){
                _pos.Xpos++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (checkLimits(-1, 0)){
                _pos.Xpos--;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (checkLimits(0, 1)){
                _pos.Ypos++;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if (checkLimits(0, -1)){
                _pos.Ypos--;
            }
        }
        transform.position = Grid.Instance.GetWorldPosCenter(_pos.Xpos, _pos.Ypos);
    }

    bool checkLimits(int xVar, int yVar){
        int newXpos = _pos.Xpos + xVar;
        int newYpos = _pos.Ypos + yVar;
        if (newXpos < 0 || newYpos < 0){
            return false;
        }
        Debug.Log(Grid.Instance.width + " " + Grid.Instance.height);
        if(newXpos > Grid.Instance.width - 1 || newYpos > Grid.Instance.height - 1){
            return false;
        }
        return true;
    }
}
