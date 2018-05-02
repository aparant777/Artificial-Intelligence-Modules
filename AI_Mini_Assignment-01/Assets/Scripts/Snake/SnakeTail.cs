﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour {

    public GameObject goLeader;

    void Update()
    {
        if (goLeader == null) return;
        Vector3 v3FromLeader = transform.position - goLeader.transform.position;
        v3FromLeader = v3FromLeader.normalized * transform.localScale.y;
        transform.position = v3FromLeader + goLeader.transform.position;
    }
}
