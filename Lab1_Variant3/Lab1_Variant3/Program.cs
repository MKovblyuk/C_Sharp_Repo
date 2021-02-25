using System;


namespace Lab1_Variant3
{
    class Program
    {
        static void Main(string[] args)
        {
            // ToShortString check
            Console.WriteLine("////////////////  ToShortString check  /////////////////////");
            ResearchTeam team = new ResearchTeam("First research","MCD",23,TimeFrame.TwoYears);
            Console.WriteLine(team.ToShortString());
            Console.WriteLine();

            // indexer check
            Console.WriteLine("////////////////  indexer check  /////////////////////");
            Console.WriteLine($"TimeFrame.Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TimeFrame.TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"TimeFrame.Long: {team[TimeFrame.Long]}");
            Console.WriteLine();

            // input data in properties
            Console.WriteLine("////////////////  input data in properties  /////////////////////");
            team.RegistrationNumber = 45;
            team.ResearchDuration = TimeFrame.Year;
            team.ResearchName = "Changed research";
            team.OrganizationName = "Organization ABC";
            team.Papers = new Paper[]{
                new Paper("name1", new Person(), new DateTime(2010, 5, 12)),
                new Paper("name2", new Person(), new DateTime(2001, 5, 12)),
                new Paper("name3", new Person(), new DateTime(2010, 7, 12)),
                new Paper("name4", new Person(), new DateTime(2010, 8, 13)),
                new Paper("name5", new Person(), new DateTime(2009, 11, 15)),
            };
            Console.WriteLine(team);
            Console.WriteLine();

            // adding new papers
            Console.WriteLine("////////////////  adding new papers  /////////////////////");
            team.AddPapers(
                new Paper("added paper1", new Person(), new DateTime(2000, 5, 12)),
                new Paper("added paper2", new Person(), new DateTime(2004, 7, 12)),
                new Paper("added paper3", new Person(), new DateTime(2007, 3, 24))
                );
            Console.WriteLine(team);
            Console.WriteLine();

            // showing last published publication
            Console.WriteLine("////////////////  showing last published publication  /////////////////////");
            Console.WriteLine(team.Paper);

            //comparison of execution time of operations
            CheckExecutionTime();
        }

        public static void CheckExecutionTime()
        {
            char[] separators = { '-', ' ', '/' };
            Console.WriteLine($"Enter count of rows and columns \nSeparators: '-', ' ', '/' ");

            string[] inputData = Console.ReadLine().Split(separators, 2);

            int nRows = Convert.ToInt32(inputData[0]);
            int nColumns = Convert.ToInt32(inputData[1]);

            // creating and initialization one-dimensional array
            Paper[] arr1 = new Paper[nRows * nColumns];
            for (int i = 0; i < nRows * nColumns; i++)
            {
                arr1[i] = new Paper();
            }

            // creating and initialization two-dimensional array
            Paper[,] arr2 = new Paper[nRows, nColumns];
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = new Paper();
                }
            }

            // creating and initialization rectangular jagged array
            Paper[][] arr3 = new Paper[nRows][];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = new Paper[nColumns];
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    arr3[i][j] = new Paper();
                }
            }


            // creating and initialization jagged array
            int nActual = 0;
            int nAll = nRows * nColumns;
            int nNewRows = 0;
            while(nAll - nActual >= 0)
            {
                nNewRows++;
                nActual += nNewRows;
            }
            nActual -= nNewRows;

            Paper[][] toothedAarray = new Paper[nNewRows][];
            for (int i = 0;i < nNewRows - 1; i++)
            {
                toothedAarray[i] = new Paper[i];
                for (int j = 0; j < toothedAarray[i].Length; j++)
                {
                    toothedAarray[i][j] = new Paper();
                }
            }

            toothedAarray[^1] = new Paper[nAll - nActual];
            for (int i = 0; i < toothedAarray[^1].Length; i++)
            {
                toothedAarray[^1][i] = new Paper();
            }


            int start;
            int end;

            Console.WriteLine($"Rows count {nRows}\nColumns count {nColumns}");

            // checking one-dimensional array
            start = Environment.TickCount;
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i].Name = "----";
            }
            end = Environment.TickCount;
            Console.WriteLine($"execution time of one-dimensional array: {end - start}");

            // checking two-dimensional array
            start = Environment.TickCount;
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j].Name = "----";
                }
            }
            end = Environment.TickCount;
            Console.WriteLine($"execution time of two-dimensional array: {end - start}");

            // checking rectangular jagged array
            Console.WriteLine($"execution time of rectangular jagged array: {ExecutionTimeJaggedArr(arr3)}");

            // checking jagged array
            Console.WriteLine($"execution time of jagged array: {ExecutionTimeJaggedArr(toothedAarray)}");
        }

        public static int ExecutionTimeJaggedArr(Paper[][] arr)
        {
            int start;
            int end;

            start = Environment.TickCount;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j].Name = "----";
                }
            }
            end = Environment.TickCount;
            return end - start;
        }

    }
}
