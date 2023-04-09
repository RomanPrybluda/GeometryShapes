using System;


namespace GeometryShapes
{
    public static class Messages
    {

        // INPUT REQUEST

        public const string INPUT_MENU_ITEM = "\n Input menu item and press ENTER: ";

        public const string INPUT_CIRCUT_RADIUS = "\n Input radius (mm): ";

        public const string INPUT_SQUARE_SIDE = "\n Input side (mm): ";

        public const string INPUT_TRIANGLE_FIRST_SIDE = "\n Input first side (mm): ";

        public const string INPUT_TRIANGLE_SECOND_SIDE = "\n Input second side (mm): ";

        public const string INPUT_TRIANGLE_THIRD_SIDE = "\n Input third side (mm): ";

        public const string INPUT_RECTANGLE_FIRST_SIDE = "\n Input width (mm): ";

        public const string INPUT_RECTANGLE_SECOND_SIDE = "\n Input height (mm): ";

        public const string INPUT_NUMBER = "\n Input Error. Enter a number greater than zero.";
        
        // INVALID MASSAGE

        public const string INVALID_INPUT_MAIN_MENU_ITEM = "\n Invalid input, menu item (1-2-3-4-5-6-7).";

        public const string INVALID_INPUT_SUB_MENU_ITEM = "\n Invalid input, menu item (1-2-3-4-5).";

        public const string INVALID_INPUT_FILE_NAME = "\n Invalid file name. Please try again";

        // ADDED MASSAGE

        public const string ADDED_NEW_SHAPE = "\n The new shape has been successfully added:";

        // VIEW MASSAGE

        public const string VIEW_NOTHNG = "\n No saved data.\n";

        // DELETE MASSAGE

        public const string DEL_SHAPE_TRIANGLE = "\n The all shapes with type Triangle were deleted.\n";

        public const string DEL_SHAPE_RECATNGLE = "\n The all shapes with type Rectangle were deleted.\n";

        public const string DEL_SHAPE_SQURE = "\n The all shapes with type Squre were deleted.\n";

        public const string DEL_SHAPE_CIRCLE = "\n The all shapes with type Cicle were deleted.\n";

        // TRANSFORM MASSAGE

        public const string TRANSFORMATION_DESCRIPTION = 
            "\n The transformation of the figures will be done as follows:" +
            "\n   - triangle to rectangle;" +
            "\n   - rectangle to triangle;" +
            "\n   - circle to square;" +
            "\n   - square to circle.\n";

        public const string TRANSFORMATION_PERFORM = "\n Do shape transformation? (y/n) :";

        public const string TRANSFORMATION_COMPLITE = "\n Transformation completed.\n";

        // SAVE MASSAGE

        public const string INPUT_FILE_NAME = "\n Input file name: ";

        public const string SAVE_SUCSESS = "\n Saving completed successfully\n";

        public const string SAVE_ASK_OVERWRITE_FILE = "\n This file already exists. Over write file (y/n) :";

        public const string SAVE_FALSE = "\n Could not save shapes to file: ";

        // UPLOAD MASSAGE

        public const string UPLOAD_SUCSESS = "\n All shapes have been uploaded\n";

        public const string UPLOAD_FALSE = "\n Could not upload shapes from file: ";

        // RETURN TO MAIN MENU

        public const string RETURN_TO_MAIN_MENU = "\n For return to Main menu press ENTER ";

        // EXIT MASSAGE

        public const string ASK_EXIT_FROM_APP = "\n Exit from application? (y/n) :";

        public const string GOODBAY = "\n" + " ------------ Good Bay ------------ ";
                                           
    }
}
