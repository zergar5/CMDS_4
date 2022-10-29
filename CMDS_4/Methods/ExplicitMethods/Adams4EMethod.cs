namespace CMDS_4.Methods.ExplicitMethods;

public class Adams4EMethod : Method
{
    public override string MethodName => "Adams4E";

    public override List<double> Solve(Func<double, double, double> function, double y, double t, int n, double h)
    {
        var solutions = new List<double> { y };
        FindInitValues(function, solutions, ref t, 3, h);
        var functionsValues = new List<double>
        {
            function(t - 4 * h, solutions[0]),
            function(t - 3 * h, solutions[1]),
            function(t - 2 * h, solutions[2]),
            function(t - h, solutions[3])
        };
        for (var i = 4; i <= n; i++, t += h)
        {
            var yNext = solutions[i - 1] + h *
            (
                55 * functionsValues[3] -
                59 * functionsValues[2] +
                37 * functionsValues[1] -
                9 * functionsValues[0]
            ) / 24;
            functionsValues.RemoveAt(0);
            functionsValues.Add(function(t, yNext));
            solutions.Add(yNext);
        }
        return solutions;
    }
}