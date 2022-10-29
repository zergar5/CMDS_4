namespace CMDS_4.Methods.ExplicitMethods;

public class Adams3EMethod : Method
{
    public override string MethodName => "Adams3E";

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
            var yNext = solutions[i - 1] + h *
            (
                23 * functionsValues[2] -
                16 * functionsValues[1] +
                5 * functionsValues[0]
            ) / 12;
            functionsValues.RemoveAt(0);
            functionsValues.Add(function(t, yNext));
            solutions.Add(yNext);
        }
        return solutions;
    }
}