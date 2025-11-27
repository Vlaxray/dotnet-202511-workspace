public class MathCheck
{
    public static int AreaOrPerimeter(int l, int w)
    {

        if (l != w)
        {
            return (l + l + w + w);
        }
        else
        {
            return (l * w);
        }
    }
}