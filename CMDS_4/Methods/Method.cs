namespace CMDS_4.Methods;

public abstract class Method : IMethod
{
    public abstract string MethodName { get; }
    public virtual void FindInitValues(Func<double, double, double> function, List<double> solutions, ref double t, int n, double h)
    {
        for (int i = 0; i < n; i++, t += h)
        {
            var yNext = RungeKutta4Method.Solve(function, solutions[i], t, h);
            solutions.Add(yNext);
        }
        t += h;
    }
    public abstract List<double> Solve(Func<double, double, double> function, double y, double t, int n, double h);
}