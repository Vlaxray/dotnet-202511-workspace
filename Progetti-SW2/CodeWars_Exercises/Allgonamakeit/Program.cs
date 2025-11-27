using System;

public static class Kata
{
    public static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft)
    {
        bool willitmakeit = (mpg * fuelLeft) >= distanceToPump;

        if (willitmakeit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
