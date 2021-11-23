﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public MeshRenderer mr;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(0, speed* Time.deltaTime);
    }
}
