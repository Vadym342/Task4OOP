using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
    class TestArray
    {
        private static Specialization[] _1dArray;
        private static Specialization[,] _2dRectangularArray;
        private static Specialization[][] _2dSteppedArray;

        private static Tuple<int, int> _dimensions;
        public static void RunArrayComparisons()
        {
            Console.WriteLine("\n\nUseless array comparisons: ");
            InitDimensions();
            InitArrays();
            PopulateArraysWithData();
            var measurementsResults = GetMeasurementsResults();

            Console.WriteLine($"1D array execution time: {measurementsResults.Item1} ms");
            Console.WriteLine($"2D rectungular array execution time: {measurementsResults.Item2} ms");
            Console.WriteLine($"2D stepped array execution time: {measurementsResults.Item3} ms");
        }

        private static void InitDimensions()
        {
            _dimensions = ReadInputDimensions();
        }

        private static Tuple<int, int> ReadInputDimensions()
        {
            Console.WriteLine("Enter two array dimension divided by anything except digis: ");
            var inputString = Console.ReadLine();
            var rawDimensions = new Regex(@"[^\d]").Split(inputString).Select(dimension => Convert.ToInt32(dimension)).ToArray();
            Console.WriteLine($"Your array dimension are: {string.Join(" and ", rawDimensions)}");
            return new Tuple<int, int>(rawDimensions[0], rawDimensions[1]);
        }

        private static void InitArrays()
        {
            _1dArray = new Specialization[_dimensions.Item1 * _dimensions.Item2];
            _2dRectangularArray = new Specialization[_dimensions.Item1, _dimensions.Item2];
            _2dSteppedArray = new Specialization[_dimensions.Item1][];
        }

        private static void PopulateArraysWithData()
        {
            Random rand = new Random();
            for (var i = 0; i < _dimensions.Item1 * _dimensions.Item2; i++)
            {
                _1dArray[i] = new Specialization();
            }

            for (int i = 0; i < _dimensions.Item1; i++)
            {
                for (var j = 0; j < _dimensions.Item2; j++)
                {
                    _2dRectangularArray[i, j] = new Specialization();
                }

                _2dSteppedArray[i] = new Specialization[rand.Next(20, 90)];
                for (var j = 0; j < _2dSteppedArray[i].Length; j++)
                {
                    _2dSteppedArray[i][j] = new Specialization();
                }
            }
        }

        private static Tuple<double, double, double> GetMeasurementsResults()
        {
            var _1dArrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++)
                {
                    _1dArray[i].Code = 122;
                }
            });

            var _2dRectangulararrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++)
                {
                    for (var j = 0; j < _dimensions.Item2; j++)
                    {
                        _2dRectangularArray[i, j].Code = 122;
                    }
                }
            });

            var _2dSteppedArrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++)
                {
                    for (var j = 0; j < _2dSteppedArray[i].Length; j++)
                    {
                        _2dSteppedArray[i][j].Code = 122;
                    }
                }
            });

            return new Tuple<double, double, double>(_1dArrayExecutionTime, _2dRectangulararrayExecutionTime, _2dSteppedArrayExecutionTime);
        }

        public static double GetMeasuredMethodExecutionTime(Action sortingMethod)
        {
            var watch = new Stopwatch();
            watch.Start();
            sortingMethod();
            watch.Stop();
            return watch.Elapsed.TotalMilliseconds;
        }


    }
}
