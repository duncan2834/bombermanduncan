using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animation mot;
    public Animation hai;
    public Animation ba;

    public void enableAnimation(Animation e)  {
        if (e == mot) {
            mot.enabled = e;
        } else if (e == hai) {
            hai.enabled = e;
        } else if (e == ba) {
            ba.enabled = e;
        }
    }

    public void SetDir(Vector2 dir) {
        if (dir.x == 0 && dir.y == -1) {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }  
        if (dir.x == 0 && dir.y == 1) {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        if (dir.x == 1 && dir.y == 0) {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        if (dir.x == -1 && dir.y == 0) {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
    }
}
