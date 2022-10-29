using CMDS_4;
using CMDS_4.Methods.ExplicitMethods;
using CMDS_4.Methods.ImplicitMethods;
using CMDS_4.Methods.PredictorCorrectorMethods;
using CMDS_4.Tools;

var t0 = 0;
var t1 = 0;
var h = 0.0;
var y = 1;

var function = Functions.Function;

Reader.Read(ref t0, ref t1, ref h);

var method = new PredictorCorrector4Method();
Solver.GetSolution(method, function, h, t0, t1, y);