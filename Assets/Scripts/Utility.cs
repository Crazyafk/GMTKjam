using UnityEngine;

public static class Utility
{
    public static Vector3 SmoothLerp(Vector3 a, Vector3 b, float t)
    {
        float x = Mathf.SmoothStep(a.x, b.x, t);
        float y = Mathf.SmoothStep(a.y, b.y, t);
        float z = Mathf.SmoothStep(a.z, b.z, t);

        return(new Vector3(x,y,z));
    }
}
