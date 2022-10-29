namespace CMDS_4.Methods.PredictorCorrectorMethods;

public abstract class PredictorCorrectorMethod : Method
{
    protected abstract double Prediction(List<double> functionsValues, double y, double h);

    protected abstract double Correction(List<double> functionsValues, double y, double h);
}