using CMDS_4.Methods;

namespace CMDS_4.Tools;

public static class Solver
{
    public static void GetSolution(Method method, Func<double, double, double> function, double h, double t0, double t1, double y)
    {
        var n = (int)((t1 - t0) / h);
        
        for (int i = 1; i <= 3; i++)
        {
            var analyticalSolution = AnalyticalSolution.Solve(y, t0, n, h);
            var methodSolution = method.Solve(function, y, t0, n, h);
            using (var fileStream = new FileStream(@"..\CMDS_4\Results\" + $"{method.MethodName} {h}.txt", FileMode.Create))
            {
                TablesCreator.Create(n, h, methodSolution, analyticalSolution, fileStream);
            }
            h /= 2;
            n = (int)((t1 - t0) / h);
        }
    }
}