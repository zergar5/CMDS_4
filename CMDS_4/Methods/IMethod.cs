namespace CMDS_4.Methods;

public interface IMethod
{
    public List<double> Solve(Func<double, double, double> function, double y, double t, int n, double h);
}