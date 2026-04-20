public class ScientificOperations
{
    private Trigonometry trig = new Trigonometry();
    private Logarithmic log = new Logarithmic();
    private PowerOperations powerOps = new PowerOperations();

    public double Sqrt(double x) => Math.Sqrt(x);
    public double power(double x, double y)
    {
        return powerOps.Power(x, y);
    }
    public double Sin(double x) => trig.Sin(x);
    public double Cos(double x) => trig.Cos(x);
    public double Tan(double x) => trig.Tan(x);
    public double Log(double x) => log.Log(x);
}