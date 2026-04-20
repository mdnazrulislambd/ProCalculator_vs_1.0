public class Trigonometry
{
    public double Sin(double x) => Math.Sin(DegToRad(x));
    public double Cos(double x) => Math.Cos(DegToRad(x));
    public double Tan(double x) => Math.Tan(DegToRad(x));

    private double DegToRad(double deg)
    {
        return deg * Math.PI / 180;
    }
}