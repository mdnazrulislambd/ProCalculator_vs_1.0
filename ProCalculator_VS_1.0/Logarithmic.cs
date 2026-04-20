public class Logarithmic
{
    public double Log(double x)
    {
        if (x <= 0) throw new Exception("Invalid input for log");
        return Math.Log10(x);
    }

    public double Ln(double x)
    {
        if (x <= 0) throw new Exception("Invalid input for ln");
        return Math.Log(x);
    }
}