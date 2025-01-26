using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoostTimerPosition : MonoBehaviour
{
    public Transform BoostIcon;
    void Update()
    {
        transform.position=BoostIcon.position+new Vector3(3,0,0);
    }
}
