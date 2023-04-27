using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreInfo
{
    public string name;
    public float score;

    public ScoreInfo(string name, float score)
    {
        this.name = name;
        this.score = score;
    }
}
