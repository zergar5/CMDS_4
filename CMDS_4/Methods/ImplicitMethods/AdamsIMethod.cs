namespace CMDS_4.Methods.ImplicitMethods;

public abstract class AdamsIMethod : Method
{
    protected abstract double FindX(List<double> functionsValues, double y, double h);

    protected abstract double Approximation(Func<double, double, double> function, List<double> functionsValues, double y,
        double x, double t, double h);
}