using NUnit.Framework;
using Homework_M8_2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common;

namespace Homework_M8_2.Tests
{
    [TestFixture()]
    public class SortTests
    {
        [TestCaseSource("TestArrays")]
        public void SortMatrixTest(int[,] sourceArray, int[,] resultsArray, SortCriteria sortBy)
        {
            // arrange
            var sortObject = new Sort();

            // act
            int[,] actual = sortObject.SortMatrix(sourceArray, sortBy);

            // assert
            // comparison of n-dimension arrays here
            bool equal = actual.Rank == resultsArray.Rank &&
                         Enumerable.Range(0, actual.Rank).All(
                             dimension => actual.GetLength(dimension) == resultsArray.GetLength(dimension)) &&
                             actual.Cast<int>().SequenceEqual(resultsArray.Cast<int>());
            Assert.That(equal);
        }

        static object[] TestArrays =
        {
            // test case #1
            new object[]
            {
                // source array
                new int[,]
                {
                    { 1, 2, 300},       // 300
                    { 10, 200, 30},     // 200
                    { 100, 200, 300},   // 300
                },
                // result array
                new int[,]
                {
                    { 10, 200, 30},     // 200
                    { 1, 2, 300},       // 300
                    { 100, 200, 300},   // 300
                },
                // type of sorting
                SortCriteria.RowMax
            },

            // test case #2
            new object[]
            {
                // source array
                new int[,]
                {
                    { 1, 2, 300},       // 1
                    { 10, 200, 30},     // 10
                    { 100, 200, -5},   // -5
                },
                // result array
                new int[,]
                {
                    { 100, 200, -5},   // -5
                    { 1, 2, 300},       // 1
                    { 10, 200, 30},     // 10
                },
                // type of sorting
                SortCriteria.RowMin
            },

            // test case #3
            new object[]
            {
                // source array
                new int[,]
                {
                    { 54, 34, 39}, // sum = 127
                    { 23, 232, 34},// sum = 289
                    { 23, 172, 40},// sum = 235
                },
                // result array
                new int[,]
                {
                    { 54, 34, 39},
                    { 23, 172, 40},
                    { 23, 232, 34},
                },
                // type of sorting
                SortCriteria.RowSum
            },

            // test case #4
            new object[]
            {
                // source array
                new int[,]
                {
                    { 54, 34, 39}, // sum = 127
                    { 23, 232, 34},// sum = 289
                    { 23, 172, 40},// sum = 235
                },
                // result array
                new int[,]
                {
                    { 23, 232, 34},
                    { 23, 172, 40},
                    { 54, 34, 39},
                },
                // type of sorting
                SortCriteria.RowSumReverse
            },

             // test case #5
            new object[]
            {
                // source array
                new int[,]
                {
                    { 1, 2, 250},       // 250
                    { 10, 200, 30},     // 200
                    { 100, 200, 300},   // 300
                },
                // result array
                new int[,]
                {
                    { 100, 200, 300},   // 300
                    { 1, 2, 250},       // 250
                    { 10, 200, 30},     // 200
                },
                // type of sorting
                SortCriteria.RowMaxReverse
            },

            // test case #6
            new object[]
            {
                // source array
                new int[,]
                {
                    { 1, 2, 300},       // 1
                    { 10, 200, 30},     // 10
                    { 100, 200, -5},   // -5
                },
                // result array
                new int[,]
                {
                    { 10, 200, 30},     // 10
                    { 1, 2, 300},       // 1
                    { 100, 200, -5},   // -5
                },
                // type of sorting
                SortCriteria.RowMinReverse
            }
        };
    }
}