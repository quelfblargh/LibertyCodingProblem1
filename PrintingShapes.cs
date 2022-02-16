using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ShapeClasses;

namespace PrintingShapes
{
    
    class PrintingShapes
    {
        public static string WHITELIST_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        public static string ERROR_MESSAGE = "I'm sorry, I didn't understand that, please try again. ";
        static void Main()
        {
            bool repeatFlag = true, validInput = true, inputFlag = true;
            string chosenShape, label, repeatInput;
            int shapeSize, labelRow;

            while (repeatFlag)
            {
                chosenShape = getShape();
                shapeSize = getSize(chosenShape);
                label = getLabel(chosenShape, shapeSize);
                labelRow = getRow(chosenShape, shapeSize, label);

                if (chosenShape == "triangle")
                {
                    Triangle shape = new Triangle(shapeSize, label, labelRow);
                    shape.outputShape();
                }
                else if (chosenShape == "diamond")
                {
                    Diamond shape = new Diamond(shapeSize, label, labelRow);
                    shape.outputShape();
                }
                else if (chosenShape == "square")
                {
                    Square shape = new Square(shapeSize, label, labelRow);
                    shape.outputShape();
                }

                inputFlag = true;
                while(inputFlag)
                {
                    do
                    {
                        Console.Write("Would you like me to print another shape? ");
                        repeatInput = Console.ReadLine();

                        foreach (char c in repeatInput)
                        {
                            if (WHITELIST_CHARACTERS.IndexOf(c) == -1)
                            {
                                Console.WriteLine(ERROR_MESSAGE + "Invalid characters used.");
                                Console.ReadKey(true);
                                validInput = false;
                                break;
                            }
                        }
                        if (!validInput)
                        {
                            validInput = true;
                            continue;
                        }
                        else
                        {
                            inputFlag = false;
                        }
                    } while (inputFlag);

                    repeatInput = repeatInput.ToLower();
                    repeatInput = Regex.Replace(repeatInput, @"\s", "");
                    if (repeatInput == "n" || repeatInput == "no")
                    {
                        repeatFlag = false;
                    }
                    else if(repeatInput == "y" || repeatInput == "yes")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(ERROR_MESSAGE + "Invalid option input.");
                        Console.ReadKey(true);
                        inputFlag = true;
                    }
                }
            }


        }

        static string getShape()
        {
            bool loopFlag = true, validInput = true, shapeFlag = true;
            string shapeInput = "";

            while (loopFlag)                                                                                                //Loop for gathering shape information
            {
                do
                {
                    Console.Write("What shape should I draw? ");
                    shapeInput = Console.ReadLine();

                    foreach (char c in shapeInput)
                    {
                        if (WHITELIST_CHARACTERS.IndexOf(c) == -1)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Invalid characters used for shape.");
                            Console.ReadKey(true);
                            validInput = false;
                            break;
                        }
                    }
                    if (!validInput)
                    {
                        validInput = true;
                    }
                    else
                        shapeFlag = false;

                } while (shapeFlag);

                shapeInput = shapeInput.ToLower();                                                                          //Makes the safe string all lowercase
                shapeInput = Regex.Replace(shapeInput, @"\s", "");                                                          //Removes whitespace

                if (shapeInput == "triangle" || shapeInput == "diamond" || shapeInput == "square")
                    loopFlag = false;
                else
                {
                    Console.WriteLine(ERROR_MESSAGE + "Invalid shape entered.");
                    shapeFlag = true;
                    Console.ReadKey(true);
                }
            }

            return shapeInput;
        }

        static int getSize(string nm)
        {
            bool sizeFlag = true, loopFlag = true, validInput = true;
            int shapeSize = 0;
            string sizeInput = "";

            while (loopFlag)
            {
                do
                {
                    Console.Write($"How tall should the {nm} be? ");
                    sizeInput = Console.ReadLine();

                    foreach (char c in sizeInput)
                    {
                        if (WHITELIST_CHARACTERS.IndexOf(c) == -1)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Invalid characters used for size.");
                            Console.ReadKey(true);
                            validInput = false;
                            break;
                        }
                    }
                    if (!validInput)
                    {
                        validInput = true;
                        continue;
                    }
                    else
                        sizeFlag = false;
                } while (sizeFlag);

                sizeInput = Regex.Replace(sizeInput, @"\s", "");

                bool parseResults = int.TryParse(sizeInput, out shapeSize);
                if (parseResults)
                {
                    if (nm == "diamond")
                    {
                        if (shapeSize < 3)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Size was less than minimum size of diamond.");
                            Console.ReadKey(true);
                        }
                        else if (shapeSize % 2 == 0)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Size of diamond must be odd.");
                            Console.ReadKey(true);
                        }
                        else
                            loopFlag = false;
                    }
                    else
                    {
                        if (shapeSize < 2)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Size was less than minimum size.");
                            Console.ReadKey(true);
                        }
                        else
                            loopFlag = false;
                    }
                }
                else
                {
                    Console.WriteLine(ERROR_MESSAGE + "Invalid size entered.");
                    Console.ReadKey(true);
                    sizeFlag = true;
                }
            }

            return shapeSize;
        }

        static string getLabel(string nm, int sz)
        {
            bool wordFlag = true, validInput = true;
            string labelInput = "";

            do
            {
                Console.Write($"What label should I print on this {nm}? (Leave blank for \"LU\"). ");
                labelInput = Console.ReadLine();

                foreach (char c in labelInput)
                {
                    if (WHITELIST_CHARACTERS.IndexOf(c) == -1)
                    {
                        Console.WriteLine(ERROR_MESSAGE + "Invalid characters used for word.");
                        Console.ReadKey(true);
                        validInput = false;
                        break;
                    }
                }
                if (!validInput)
                {
                    validInput = true;
                    continue;
                }
                else
                {
                    labelInput = labelInput.ToUpper();
                    labelInput = Regex.Replace(labelInput, @"\s", "");

                    if (nm == "diamond")
                    {
                        if (labelInput.Length > (sz + 1) / 2)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Length is too long for diamond.");
                            Console.ReadKey(true);
                        }
                        else if (labelInput == "")
                        {
                            labelInput = "LU";
                            wordFlag = false;
                        }
                        else
                            wordFlag = false;
                    }
                    else
                    {
                        if (labelInput.Length > sz)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Length is too long for shape.");
                            Console.ReadKey(true);
                        }
                        else if (labelInput == "")
                        {
                            labelInput = "LU";
                            wordFlag = false;
                        }
                        else
                            wordFlag = false;
                    }
                }
            } while (wordFlag);

            return labelInput;
        }

        static int getRow(string nm, int sz, string lbl)
        {
            bool loopFlag = true, rowFlag = true, validInput = true;
            string rowInput = "";
            int labelOnRow = 0;

            while (loopFlag)
            {
                do
                {
                    Console.Write($"On what row should I print \"{lbl}\"? ");
                    rowInput = Console.ReadLine();

                    foreach (char c in rowInput)
                    {
                        if (WHITELIST_CHARACTERS.IndexOf(c) == -1)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Invalid characters used for row number.");
                            Console.ReadKey(true);
                            validInput = false;
                            break;
                        }
                    }
                    if (!validInput)
                    {
                        validInput = true;
                        continue;
                    }
                    else
                        rowFlag = false;
                } while (rowFlag);

                rowInput = Regex.Replace(rowInput, @"\s", "");

                bool parseResults = int.TryParse(rowInput, out labelOnRow);
                if (parseResults)
                {
                    if (labelOnRow < 1)
                    {
                        Console.WriteLine(ERROR_MESSAGE + "Negative or zero row number entered.");
                        Console.ReadKey(true);
                        rowFlag = true;
                    }
                    else if (labelOnRow > sz)
                    {
                        Console.WriteLine(ERROR_MESSAGE + "Row number larger than size of shape.");
                        Console.ReadKey(true);
                        rowFlag = true;
                    }
                    else if (nm == "diamond")
                    {
                        if (labelOnRow <= (sz + 1) / 2) //Top half of diamond
                        {
                            if (lbl.Length > labelOnRow)
                            {
                                Console.WriteLine(ERROR_MESSAGE + "Row on diamond cannot fit label (upper half).");
                                Console.ReadKey(true);
                                rowFlag = true;
                            }
                            else
                                loopFlag = false;
                        }
                        else if (labelOnRow > (sz + 1) / 2) //Bottom half of diamond
                        {
                            if (lbl.Length > ((sz + 1) - labelOnRow))
                            {
                                Console.WriteLine(ERROR_MESSAGE + "Row on diamond cannot fit label (lower half).");
                                Console.ReadKey(true);
                                rowFlag = true;
                            }
                            else
                                loopFlag = false;
                        }

                    }
                    else if (nm == "triangle")
                    {
                        if (lbl.Length > labelOnRow)
                        {
                            Console.WriteLine(ERROR_MESSAGE + "Row on triangle cannot fit label.");
                            Console.ReadKey(true);
                            rowFlag = true;
                        }
                        else
                            loopFlag = false;
                    }
                    else //Shape is square
                        loopFlag = false;
                }

                else
                {
                    Console.WriteLine(ERROR_MESSAGE + "Invalid row number entered.");
                    Console.ReadKey(true);
                    rowFlag = true;
                }
            }
            return labelOnRow;
        }
    }

    
}
