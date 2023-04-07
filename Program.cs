using GeometryTest;

WindowTuner.SetWinPror();

var cui = new Cui();

var fm = new FileManager();
var dm = new DataManager(fm);

var vTriangle = new ValidatorTriangle();
var vRectangle = new ValidatorRectangle();
var vSquare = new ValidatorSquare();
var vCircle = new ValidatorCircle();

cui.CuiApp(dm, fm, vTriangle, vRectangle, vSquare, vCircle);