using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math{
    public Vector2 temp(int x, int y)
    {
        return getHexaPos(x, y, 18, 10);
    }

    public Vector2 getHexaPos(int x, int y, int width, int height)
    {
        Vector2 res = new Vector2();
        int line_p = (y / height);
        int line_i = (y - ((height / 2) - 1) < 0) ? -1 : (y - ((height / 2) - 1) / height);

        int len = (width - Diff(0, height)) * 2 - 1;
        int offset = Diff(y, height);
        if (x - offset < 0)
            return new Vector2(-1, line_i);
        else if ((x - offset) % len > width - offset * 2)
            return new Vector2((x - offset) / len, line_i);
        return new Vector2((x - offset) / len, line_i);
    }
    public int Diff(int y, int height)
    {
        return ((int)Mathf.Ceil(Mathf.Abs(y % height - (height / 2 - 0.5f))));
    }
}