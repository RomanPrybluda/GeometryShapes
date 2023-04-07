using System;


namespace GeometryTest
{
    public class Cui
    {
        public Cui()
        {
          
        }

        public void CuiApp(DataManager dm, FileManager fm, ValidatorTriangle vTriangle, ValidatorRectangle vRectangle, ValidatorSquare vSquare, ValidatorCircle vCircle)
        {

            while (true)
            {
                Console.WriteLine(Menu.MAIN_MENU);
                int itemMainMenu = ValidatorMenu.GetValidInputMainMenu();

                Console.Clear();

                switch (itemMainMenu) // Main menu
                {

                    case 1: // Add a new shape
                        {
                            Console.WriteLine(Menu.TOP_ADD);
                            Console.WriteLine(Menu.SUB_MENU);
                            int itemSubMenu = ValidatorMenu.GetValidInputSubMenu();
                            Console.Clear();

                            switch (itemSubMenu) // Add type shape
                            {
                                case 1: // Add a new triangle
                                    {
                                        Console.WriteLine(Menu.TOP_ADD_TRIANGLE);

                                        vTriangle.ToValidateTriangle(dm);

                                        break; 
                                    }

                                case 2: // Add a new rectangle
                                    {
                                        Console.WriteLine(Menu.TOP_ADD_RECTANGLE);

                                        vRectangle.ToValidateRectangle(dm);

                                        break; 
                                    }

                                case 3: // Add a new square
                                    {
                                        Console.WriteLine(Menu.TOP_ADD_SQUARE);

                                        vSquare.ToValidateSquare(dm);

                                        break; 
                                    }

                                case 4: // Add a new cicle
                                    {
                                        Console.WriteLine(Menu.TOP_ADD_CIRCLE);

                                        vCircle.ToValidateCircle(dm);

                                        break;
                                    }

                                case 5: // Add cancel
                                    {
                                        Console.WriteLine(Menu.TOP_ADD);
                                        break;
                                    }
                            }

                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {;}
                            Console.Clear();
                            break;
                        }

                    case 2: // View all shapes
                        {
                            Console.WriteLine(Menu.TOP_VIEW);

                            dm.ViewAllShapes();

                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }
                            break;
                        }

                    case 3: // Delete shapes
                        {
                            Console.WriteLine(Menu.TOP_DELETE);
                            Console.WriteLine(Menu.SUB_MENU);
                            int itemSubMenu = ValidatorMenu.GetValidInputSubMenu();
                            Console.Clear();

                            switch (itemSubMenu) // Delete type shape
                            {
                                

                                case 1: // Delete Triangle
                                    {
                                        Console.WriteLine(Menu.TOP_DELETE);

                                        dm.DeleteTypeShapes("Triangle");

                                        Console.Write(Massage.DEL_SHAPE_TRIANGLE);
                                        break;
                                    }

                                case 2: // Delete Rectangle
                                    {
                                        Console.WriteLine(Menu.TOP_DELETE);

                                        dm.DeleteTypeShapes("Rectangle");

                                        Console.Write(Massage.DEL_SHAPE_RECATNGLE);

                                        break;
                                    }

                                case 3: // Delete Squre
                                    {
                                        Console.WriteLine(Menu.TOP_DELETE);

                                        dm.DeleteTypeShapes("Square");

                                        Console.Write(Massage.DEL_SHAPE_SQURE);
                                        break;
                                    }

                                case 4: // Delete Cicle
                                    {
                                        Console.WriteLine(Menu.TOP_DELETE);

                                        dm.DeleteTypeShapes("Circle");

                                        Console.Write(Massage.DEL_SHAPE_CIRCLE);
                                        break;
                                    }
                            }
                            
                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }

                            break;
                        }

                    case 4: // Perform the transformation
                        {
                            Console.Write(Menu.TOP_TRANSFORM);

                            Console.Write(Massage.TRANSFORMATION_DESCRIPTION);
                            Console.Write(Massage.TRANSFORMATION_PERFORM);
                            
                            string askToTransform = Console.ReadLine();

                            if (askToTransform.ToLower() == "y")
                            {
                                dm.TransformShapes();
                                
                                Console.Write(Massage.RETURN_TO_MAIN_MENU);
                                Console.ReadKey();
                                break;
                            }
                                                        
                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }

                            break;

                        }

                    case 5: // Save shapes
                        {
                            Console.Write(Menu.TOP_SAVE);
                            
                            fm.SaveJsonToFile(dm);
                                                        
                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }

                            break;
                        }

                    case 6: // Upload shapes
                        {
                            Console.Write(Menu.TOP_UPLOAD);

                            dm.UploadShapes(fm);
                            
                            Console.Write(Massage.RETURN_TO_MAIN_MENU);
                            while (Console.ReadKey().Key != ConsoleKey.Enter) {; }

                            break;
                        }

                    case 7: // Exit from App
                        {
                            ExitFromApp();

                            break;
                        }

                }
                                
                Console.Clear();
            }

        }


        public void ExitFromApp()
        {
            Console.Clear();

            Console.Write(Menu.TOP_EXIT);

            Console.Write(Massage.ASK_EXIT_FROM_APP);

            var exit = Console.ReadLine();

            if (exit.ToLower() == "y")
            {
                Console.Write(Massage.GOODBAY);
                Thread.Sleep(1200);
                Environment.Exit(0);
            }

        }

    }
}
