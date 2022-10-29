namespace CMDS_4.Methods.PredictorCorrectorMethods;

public class PredictorCorrector4Method : Method
{
    public override string MethodName => "PEC4";

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
            var yPrediction = Prediction(functionsValues, solutions[i - 1], h);
            var fPrediction = function(t, yPrediction);
            functionsValues.RemoveAt(0);
            functionsValues.Add(fPrediction);

            var yNext = Correction(functionsValues, solutions[i - 1], h);
            var fNext = function(t, yNext);
            functionsValues.RemoveAt(3);
            functionsValues.Add(fNext);
            solutions.Add(yNext);
        }
        return solutions;
    }
    private double Prediction(List<double> functionsValues, double y, double h)
    {
        var yPrediction = y + h *
        (
            55 * functionsValues[3] -
            59 * functionsValues[2] +
            37 * functionsValues[1] -
            9 * functionsValues[0]
        ) / 24;
        return yPrediction;
    }

    private double Correction(List<double> functionsValues, double y, double h)
    {
        var yNext = y + h *
        (
            9 * functionsValues[3] +
            19 * functionsValues[2] -
            5 * functionsValues[1] +
            functionsValues[0]
        ) / 24;
        return yNext;
    }
}