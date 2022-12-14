namespace CMDS_4.Methods.ImplicitMethods;

public class Adams4IMethod : AdamsIMethod
{
    public override string MethodName => "Adams4I";

    public override List<double> Solve(Func<double, double, double> function, double y, double t, int n, double h)
    {
        var solutions = new List<double> { y };
        FindInitValues(function, solutions, ref t, 2, h);
        var functionsValues = new List<double>
        {
            function(t - 3 * h, solutions[0]),
            function(t - 2 * h, solutions[1]),
            function(t - h, solutions[2])
        };
        for (var i = 3; i <= n; i++, t += h)
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

    protected override double FindX(List<double> functionsValues, double y, double h)
    {
        var x = y + h *
        (
            23 * functionsValues[2] -
            16 * functionsValues[1] +
            5 * functionsValues[0]
        ) / 12;
        return x;
    }

    protected override double Approximation(Func<double, double, double> function, List<double> functionsValues, double y, double x, double t, double h)
    {
        var fX = y + h *
        (
            9 * function(t, x) +
            19 * functionsValues[2] -
            5 * functionsValues[1] +
            functionsValues[0]
        ) / 24 - x;
        var dFx = h * (9 * 2 * t) / 24 - 1;
        return fX / dFx;
    }
}