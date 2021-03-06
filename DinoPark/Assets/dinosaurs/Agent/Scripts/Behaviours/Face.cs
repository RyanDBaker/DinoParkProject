﻿using UnityEngine;
using System.Collections;

public class Face : Align {

    public static Transform enemyTarget;

    protected GameObject targetAux;

    public override void Awake()
    {
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position; //targetAux.transform.position enemyTarget.position
        if (direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            target.GetComponent<Agent>().orientation = targetOrientation;
        }
        return base.GetSteering();
    }

    void OnDestroy ()
    {
        Destroy(target);
    }
}
