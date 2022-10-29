namespace CMDS_4.Methods.ImplicitMethods;

public class Adams3IMethod : Method
{
    public override string MethodName => "Adams3I";

    public override List<double> Solve(Func<double, double, double> function, double y, double t, int n, double h)
    {
        var solutions = new List<double> { y };
        FindInitValues(function, solutions, ref t, 1, h);
        var functionsValues = new List<double>
        {
            function(t - 2 * h, solutions[0]),
            function(t - h, solutions[1])
        };
        for (var i = 2; i <= n; i++, t += h)
        {
            var x = FindX(functionsValues, solutions[i - 1], h);
            var xNext = x - Approximation(function, functionsValues, solutions[i - 1], x, t, h);
            while (Math.Abs(xNext - x) > 2.20e-16)
            {
                x = xNext;
                xNext = x - Approximation(function, functionsValues, solutions[i - 1], x, t, h);
            }
            var fNext = function(t, xNext);
            functionsValues.RemoveAt(0);
            functionsValues.Add(fNext);
            solutions.Add(xNext);
        }
        return solutions;
    }

    private double FindX(List<double> functionsValues, double y, double h)
    {
        var x = y + h *
        (
            3 * functionsValues[1] -
            functionsValues[0]
        ) / 2;
        return x;
    }

    private double Approximation(Func<double, double, double> function, List<double> functionsValues, double y, double x, double t, double h)
    {
        var fX = y + h *
        (
            5 * function(t, x) +
            8 * functionsValues[1] -
            functionsValues[0]
        ) / 12 - x;
        var dFx = h * (5 * 2 * t) / 12 - 1;
        return fX / dFx;
    }
}