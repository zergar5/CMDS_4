namespace CMDS_4.Methods;

public static class RungeKutta4Method
{
    public static double Solve(Func<double, double, double> function, double y, double t, double h)
    {
        var k1 = function(t, y);
        var k2 = function(t + h / 2, y + h / 2 * k1);
        var k3 = function(t + h / 2, y + h / 2 * k2);
        var k4 = function(t + h, y + h * k3);
        var solution = y + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        return solution;
    }
}