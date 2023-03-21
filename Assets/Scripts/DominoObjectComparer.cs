using System;
using System.Collections.Generic;

public class DominoObjectComparer : Comparer<DominoObject>
{
    public override int Compare(DominoObject x, DominoObject y)
    {
        if (x.IsDouble && y.IsDouble)
        {
            if (x.Points > y.Points)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        else if (x.IsDouble && !y.IsDouble)
        {
            return -1;
        }
        else if (!x.IsDouble && y.IsDouble)
        {
            return 1;
        }
        else
        {
            if (x.Points > y.Points)
            {
                return -1;
            }
            else if (x.Points == y.Points)
            {
                if (x.Tail > y.Tail)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}