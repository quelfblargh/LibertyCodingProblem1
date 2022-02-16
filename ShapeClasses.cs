using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShapeClasses
{
    abstract class Shapes
    {
        private int size, row;
        private string label;

        public Shapes(int sz, string lbl, int rw)
        {
            Size = sz;
            Label = lbl;
            Row = rw;
        }
        ~Shapes() { Console.WriteLine("Shapes dtor."); }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Label
        {
            get { return label; }
            set { label = value; }
        }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public abstract void outputShape();
    }

    class Triangle : Shapes
    {
        public Triangle(int sz, string lbl, int rw) : base(sz, lbl, rw) { }
        ~Triangle() { Console.WriteLine("Triangle dtor."); }

        public override void outputShape()
        {
            for (int currRow = 1; currRow <= base.Size; ++currRow)
            {
                int labelCount = 0, startingPos = 0;

                for (int spacing = base.Size - currRow; spacing > 0; --spacing)
                    Console.Write(" ");
                if (currRow == base.Row)
                {
                    labelCount = currRow;
                    startingPos = ((currRow - base.Label.Length)/2) + 1;
                    
                    for(int init = 1; init < startingPos; ++init)
                    {
                        Console.Write("X ");
                        --labelCount;
                    }
                    foreach (char c in base.Label)
                    {
                        Console.Write($"{c} ");
                        --labelCount;
                    }
                    for (int rem = labelCount; rem > 0; --rem)
                        Console.Write("X ");
                }
                else
                {
                    for (int symbols = 1; symbols <= currRow; ++symbols)
                        Console.Write("X ");
                }
                Console.Write($"{ Environment.NewLine}");
            }
        }
    }

    class Square : Shapes
    {
        public Square(int sz, string lbl, int rw) : base(sz, lbl, rw) { }
        ~Square() { Console.WriteLine("Square dtor."); }

        public override void outputShape()
        {
            for (int currRow = 1; currRow <= base.Size; ++currRow)
            {
                int labelCount = 0, startingPos = 0;

                if (currRow == base.Row)
                {
                    labelCount = base.Size;
                    startingPos = ((base.Size - base.Label.Length) / 2) + 1;

                    for (int init = 1; init < startingPos; ++init)
                    {
                        Console.Write("X ");
                        --labelCount;
                    }
                    foreach (char c in base.Label)
                    {
                        Console.Write($"{c} ");
                        --labelCount;
                    }
                    for (int rem = labelCount; rem > 0; --rem)
                        Console.Write("X ");
                }
                else
                {
                    for (int symbols = 1; symbols <= base.Size; ++symbols)
                        Console.Write("X ");
                }
                Console.Write($"{ Environment.NewLine}");
            }
        }
    }

    class Diamond : Shapes
    {
        private int middleRow;

        public Diamond(int sz, string lbl, int rw) : base(sz, lbl, rw)
        {
            middleRow = (sz + 1) / 2;
        }
        ~Diamond() { Console.WriteLine("Diamond dtor."); }

        public int MiddleRow
        {
            get { return middleRow; }
            set { middleRow = value; }
        }

        public override void outputShape()
        {
            for (int currRow = 1; currRow < MiddleRow; ++currRow)
            {
                int labelCount = 0, startingPos = 0;
                
                for (int spacing = MiddleRow - currRow; spacing > 0; --spacing)
                    Console.Write(" ");
                if (currRow == base.Row)
                {
                    labelCount = currRow;
                    startingPos = ((currRow - base.Label.Length) / 2) + 1;

                    for (int init = 1; init < startingPos; ++init)
                    {
                        Console.Write("X ");
                        --labelCount;
                    }
                    foreach (char c in base.Label)
                    {
                        Console.Write($"{c} ");
                        --labelCount;
                    }
                    for (int rem = labelCount; rem > 0; --rem)
                        Console.Write("X ");
                }
                else
                {
                    for (int symbols = 1; symbols <= currRow; ++symbols)
                        Console.Write("X ");
                }    
                Console.Write($"{ Environment.NewLine}");
            }
            for (int currRow = MiddleRow; currRow >= 1; --currRow)
            {
                int labelCount = 0, startingPos = 0;
                
                for (int spacing = MiddleRow - currRow; spacing > 0; --spacing)
                    Console.Write(" ");
                if(base.Row == ((MiddleRow - currRow) + MiddleRow))
                {
                    labelCount = currRow;
                    startingPos = ((currRow - base.Label.Length) / 2) + 1;

                    for (int init = 1; init < startingPos; ++init)
                    {
                        Console.Write("X ");
                        --labelCount;
                    }
                    foreach (char c in base.Label)
                    {
                        Console.Write($"{c} ");
                        --labelCount;
                    }
                    for (int rem = labelCount; rem > 0; --rem)
                        Console.Write("X ");
                }
                else
                {
                    for (int symbols = currRow; symbols > 0; --symbols)
                        Console.Write("X ");
                }
                Console.Write($"{ Environment.NewLine}");
            }
        }
    }
}
