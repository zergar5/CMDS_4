namespace CMDS_4.Methods
{
    public static class AnalyticalSolution
    {
        public static List<double> Solve(double y, double t, int n, double h)
        {
            List<double> result = new List<double> { y };
            t = h;
            for (int i = 1; i <= n; i++, t += h)
            {
                y = Equation(t);
                result.Add(y);
            }
            return result;
        }

        private static double Equation(double t) => Math.Exp(t * t);
    }
}