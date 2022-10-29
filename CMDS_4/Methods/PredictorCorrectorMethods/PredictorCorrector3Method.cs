namespace CMDS_4.Methods.PredictorCorrectorMethods;

public class PredictorCorrector3Method : Method
{
    public override string MethodName => "PEC3";

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
            var yPrediction = Prediction(functionsValues, solutions[i - 1], h);
            var fPrediction = function(t, yPrediction);
            functionsValues.RemoveAt(0);
            functionsValues.Add(fPrediction);

            var yNext = Correction(functionsValues, solutions[i - 1], h);
            var fNext = function(t, yNext);
            functionsValues.RemoveAt(2);
            functionsValues.Add(fNext);
            solutions.Add(yNext);
        }
        return solutions;
    }

    private double Prediction(List<double> functionsValues, double y, double h)
    {
        var yPrediction = y + h *
        (
            23 * functionsValues[2] -
            16 * functionsValues[1] +
            5 * functionsValues[0]
        ) / 12;
        return yPrediction;
    }

    private double Correction(List<double> functionsValues, double y, double h)
    {
        var yNext = y + h *
        (
            5 * functionsValues[2] +
            8 * functionsValues[1] -
            functionsValues[0]
        ) / 12;
        return yNext;
    }
}