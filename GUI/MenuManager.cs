using GeometryShapes.GUI.InputPerformers;
using GeometryShapes.Shapes;
using System;


namespace GeometryShapes
{
    public class MenuManager
    {

        private ShapeManager _shapeManager;

        public MenuManager(ShapeManager shapeManager)
        {
            _shapeManager = shapeManager;

            Print();
        }

        public void Print()
        {

            while (true)
            {
                Console.WriteLine(MenuItems.MAIN_MENU);

                var inputMainMenu = InputMenuPerformer.PerformMainMenuInput();

                Console.Clear();

                switch (inputMainMenu) // Main menu
                {

                    case 1: // Add a new shape
                        {
                            Console.WriteLine(MenuItems.TOP_ADD);
                            Console.WriteLine(MenuItems.SUB_MENU);

                            int inputSubMenu = InputMenuPerformer.PerformSubMenuInput();

                            Console.Clear();

                            switch (inputSubMenu) // Add type shape
                            {
                                case 1: // Add a new triangle
                                    {
                                        Console.WriteLine(MenuItems.TOP_ADD_TRIANGLE);

                                        InputTrianglePerformer getSidesTriangle = new InputTrianglePerformer();
                                        var sidesTriangle = getSidesTriangle.PerformTriangleInput();
                                        _shapeManager.AddTriangle(sidesTriangle.Item1, sidesTriangle.Item2, sidesTriangle.Item3);

                                        PrintAddedShape();
                                        GoToMainMenu();
                                        break;
                                    }

                                case 2: // Add a new rectangle
                                    {
                                        Console.WriteLine(MenuItems.TOP_ADD_RECTANGLE);

                                        InputRectanglePerformer getSidesRectangle = new InputRectanglePerformer();
                                        var sidesRectangle = getSidesRectangle.PerformRectangleInput();
                                        _shapeManager.AddRectangle(sidesRectangle.Item1, sidesRectangle.Item2);

                                        PrintAddedShape();
                                        GoToMainMenu();
                                        break;
                                    }

                                case 3: // Add a new square
                                    {
                                        Console.WriteLine(MenuItems.TOP_ADD_SQUARE);

                                        InputSquarePerformer getSideSquare = new InputSquarePerformer();
                                        var sideSquare = getSideSquare.PerformSquareInput();
                                        _shapeManager.AddSquare(sideSquare);

                                        PrintAddedShape();
                                        GoToMainMenu();
                                        break;
                                    }

                                case 4: // Add a new cicle
                                    {
                                        Console.WriteLine(MenuItems.TOP_ADD_CIRCLE);

                                        InputCirclePerformer inputCicle = new InputCirclePerformer();
                                        var radius = inputCicle.PerformCircleInput();
                                        _shapeManager.AddCircle(radius);

                                        PrintAddedShape();
                                        GoToMainMenu();
                                        break;
                                    }

                                case 5: // Add cancel
                                    {
                                        Console.WriteLine(MenuItems.TOP_ADD);
                                        break;
                                    }
                            }
                            break;

                        }

                    case 2: // View all shapes
                        {
                            Console.WriteLine(MenuItems.TOP_VIEW);

                            if (_shapeManager.GetShapes().Count() == 0)
                                Console.Write(Messages.VIEW_NOTHNG);

                            foreach (var shape in _shapeManager.GetShapes())
                                Console.WriteLine(shape);

                            GoToMainMenu();
                            break;
                        }

                    case 3: // Delete shapes
                        {
                            Console.WriteLine(MenuItems.TOP_DELETE);
                            Console.WriteLine(MenuItems.SUB_MENU);
                            int inputSubMenu = InputMenuPerformer.PerformSubMenuInput();
                            Console.Clear();

                            switch (inputSubMenu) // Delete type shape
                            {


                                case 1: // Delete Triangle
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        _shapeManager.DeleteShapeByType(ShapeType.Triangle);

                                        Console.Write(Messages.DEL_SHAPE_TRIANGLE);
                                        GoToMainMenu();
                                        break;
                                    }

                                case 2: // Delete Rectangle
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        _shapeManager.DeleteShapeByType(ShapeType.Rectangle);

                                        Console.Write(Messages.DEL_SHAPE_RECATNGLE);
                                        GoToMainMenu();
                                        break;
                                    }

                                case 3: // Delete Squre
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        _shapeManager.DeleteShapeByType(ShapeType.Square);

                                        Console.Write(Messages.DEL_SHAPE_SQURE);
                                        GoToMainMenu();
                                        break;
                                    }

                                case 4: // Delete Cicle
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        _shapeManager.DeleteShapeByType(ShapeType.Circle);

                                        Console.Write(Messages.DEL_SHAPE_CIRCLE);
                                        GoToMainMenu();
                                        break;
                                    }

                                default:
                                    {
                                        break;
                                    }

                            }

                            break;
                        }

                    case 4: // Perform the transformation
                        {
                            Console.Write(MenuItems.TOP_TRANSFORM);

                            Console.Write(Messages.TRANSFORMATION_DESCRIPTION);
                            Console.Write(Messages.TRANSFORMATION_PERFORM);

                            string askToTransform = Console.ReadLine();

                            if (askToTransform.ToLower() == "y")
                            {
                                _shapeManager.TransformShapes();

                                GoToMainMenu();
                                break;
                            }

                            GoToMainMenu();
                            break;

                        }

                    case 5: // Save shapes
                        {
                            Console.Write(MenuItems.TOP_SAVE);

                            //try
                            //{
                            //    _shapeManager.Save();
                            //}
                            //catch (Exception)
                            //{
                            //    Console.WriteLine(Messages.SAVE_FALSE);
                            //}

                            bool isOverwrite = false;
                            string fileName, filePath;


                            do
                            {
                                Console.Write(Messages.INPUT_FILE_NAME);
                                fileName = Console.ReadLine();

                                _shapeManager.Save(fileName);

                                //fileName = ValidatorFileName.GetValidFileName();
                                //filePath = BuildFilePath(fileName);

                                if (File.Exists(filePath))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write($"\n File {fileName} already exists. Overwrite this file (y/n) :");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    string askToOverwriteFile = Console.ReadLine();

                                    if (askToOverwriteFile.ToLower() == "y")
                                    {
                                        isOverwrite = true;
                                    }
                                    else
                                    {
                                        isOverwrite = false;
                                    }
                                }

                                else
                                {
                                    isOverwrite = true;
                                }

                            } while (!isOverwrite);

                            try
                            {
                                using (StreamWriter sw = new StreamWriter(filePath))
                                {
                                    string json = dm.GetShapesAsJson();
                                    sw.Write(json);
                                }

                                Console.WriteLine(Messages.SAVE_SUCSESS);
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(Messages.SAVE_FALSE + fileName + ex.Message);
                            }

                            GoToMainMenu();
                            break;
                        }

                    case 6: // Upload shapes
                        {
                            Console.Write(MenuItems.TOP_UPLOAD);

                            _shapeManager.Load();

                            GoToMainMenu();
                            break;
                        }

                    case 7: // Exit from App
                        {
                            ExitFromApp();

                            break;
                        }

                    default:
                        {
                            break;
                        }

                }

                Console.Clear();
            }

        }

        public void PrintAddedShape()
        {
            Console.WriteLine(Messages.ADDED_NEW_SHAPE);
            var lastShape = _shapeManager.GetShapes().LastOrDefault();
            if (lastShape != null)
            {
                Console.WriteLine(lastShape);
            }
        }

        public void GoToMainMenu()
        {
            Console.Write(Messages.RETURN_TO_MAIN_MENU);
            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }
            Console.Clear();
        }

        public void ExitFromApp()
        {
            Console.Clear();

            Console.Write(MenuItems.TOP_EXIT);

            Console.Write(Messages.ASK_EXIT_FROM_APP);

            var exit = Console.ReadLine();

            if (exit.ToLower() == "y")
            {
                Console.Write(Messages.GOODBAY);
                Thread.Sleep(1200);
                Environment.Exit(0);
            }

        }

    }
}