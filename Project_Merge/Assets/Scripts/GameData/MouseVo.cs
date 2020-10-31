using System;
using UnityEngine;

public class MouseVo
{
    public int  id { get; set; }
    public string name { get; set; }
    public string  desc { get; set; }
    public Sprite sprite { get; set; }


    public MouseVo(int ID ,string NAME,string DESC,Sprite SPRITE)
    {
        id = ID;
        name = NAME;
        desc = DESC;
        sprite = SPRITE;
    }
}
