using GeometryTest;
using System;


namespace GeometryTest
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
                                        
                                        if (!_shapeManager.CheckIfShapesExist(ShapeType.Triangle))
                                        {
                                            Console.WriteLine(" Triangles are not in the list of shapes. Choose another type of figure.");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _shapeManager.DeleteShapeByType(ShapeType.Triangle);
                                                Console.Write(Messages.DEL_SHAPE_TRIANGLE);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(Messages.DEL_SHAPE_FALSE + " " + ex.Message);
                                                break;
                                            }
                                        }

                                        GoToMainMenu();
                                        break;
                                    }

                                case 2: // Delete Rectangle
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        if (!_shapeManager.CheckIfShapesExist(ShapeType.Rectangle))
                                        {
                                            Console.WriteLine(" Rectangles are not in the list of shapes. Choose another type of figure.");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _shapeManager.DeleteShapeByType(ShapeType.Rectangle);
                                                Console.Write(Messages.DEL_SHAPE_RECATNGLE);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(Messages.DEL_SHAPE_FALSE + " " + ex.Message);
                                                break;
                                            }
                                        }
                                                                                
                                        GoToMainMenu();
                                        break;
                                    }

                                case 3: // Delete Squre
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        if (!_shapeManager.CheckIfShapesExist(ShapeType.Square))
                                        {
                                            Console.WriteLine(" Squres are not in the list of shapes. Choose another type of figure.");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _shapeManager.DeleteShapeByType(ShapeType.Square);
                                                Console.Write(Messages.DEL_SHAPE_SQURE);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(Messages.DEL_SHAPE_FALSE + " " + ex.Message);
                                                break;
                                            }
                                        }
                                                                                
                                        GoToMainMenu();
                                        break;
                                    }

                                case 4: // Delete Circle
                                    {
                                        Console.WriteLine(MenuItems.TOP_DELETE);

                                        if (!_shapeManager.CheckIfShapesExist(ShapeType.Circle))
                                        {
                                            Console.WriteLine(" Circles are not in the list of shapes. Choose another type of figure.");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _shapeManager.DeleteShapeByType(ShapeType.Circle);
                                                Console.Write(Messages.DEL_SHAPE_CIRCLE);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(Messages.DEL_SHAPE_FALSE + " " + ex.Message);
                                                break;
                                            }
                                        }

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

                                try
                                {
                                    _shapeManager.TransformShapes();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(Messages.TRANSFORMATION_FALSE + " " + ex.Message);
                                }

                                Console.Write(Messages.TRANSFORMATION_COMPLITE);
                                GoToMainMenu();
                                break;
                            }

                            GoToMainMenu();
                            break;

                        }

                    case 5: // Save shapes
                        {
                            Console.Write(MenuItems.TOP_SAVE);

                            bool isOverwrite = false;
                            string fileNameInput;

                            do
                            {
                                Console.Write(Messages.INPUT_FILE_NAME);
                                fileNameInput = Console.ReadLine();

                                if (_shapeManager.FileManager.CheckExists(fileNameInput))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write($"\n File \"{fileNameInput}.json\" already exists. Overwrite this file (y/n): ");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    string askToOverwriteFile = Console.ReadLine();

                                    if (askToOverwriteFile.ToLower() == "y")
                                    {
                                        isOverwrite = true;
                                    }
                                    else
                                    {
                                        isOverwrite = false;
                                        continue;
                                    }
                                }
                                else
                                {
                                    isOverwrite = true;
                                }

                            } while (!isOverwrite);

                            try
                            {
                                _shapeManager.Save(fileNameInput);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(Messages.SAVE_FALSE + fileNameInput + ex.Message);
                            }

                            Console.WriteLine(Messages.SAVE_SUCSESS);
                            GoToMainMenu();
                            break;
                        }

                    case 6: // Upload shapes
                        {
                            Console.Write(MenuItems.TOP_UPLOAD);

                            bool isOverwrite = false;
                            string fileNameInput;

                            do
                            {
                                Console.Write(Messages.INPUT_FILE_NAME);
                                fileNameInput = Console.ReadLine();

                                if (!_shapeManager.FileManager.CheckExists(fileNameInput))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                                    Console.Write($"\n File \"{fileNameInput}.json\" does not exist.");

                                    Console.WriteLine(Messages.INVALID_INPUT_FILE_NAME);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                else
                                {
                                    break;
                                }

                            } while (true);

                            try
                            {
                                _shapeManager.Load(fileNameInput);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(Messages.UPLOAD_FALSE + "\"" + fileNameInput + ".json\" ." + ex.Message);
                            }

                            Console.WriteLine(Messages.UPLOAD_SUCSESS);
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