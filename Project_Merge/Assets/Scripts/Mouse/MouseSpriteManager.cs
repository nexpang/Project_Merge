using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpriteManager : Singleton<MouseSpriteManager>
{
    [SerializeField]
    public List<GameObject> TileSprites = new List<GameObject>();
}