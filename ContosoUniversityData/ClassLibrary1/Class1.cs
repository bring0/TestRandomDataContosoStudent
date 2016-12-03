using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ClassLibrary1
{
    public static class Generator
    {
        private static Assembly _assembly = Assembly.GetExecutingAssembly();
        private static Stream _imageStream;
        private static StreamReader _textStreamReader;
        private static Random rand = new Random();

        private static List<string> FirstNameList =
            _enumerateLines(new StreamReader(_assembly.GetManifestResourceStream("ClassLibrary1.first_names.txt")))
                .ToList();

        private static List<string> LastNameList =
           _enumerateLines(new StreamReader(_assembly.GetManifestResourceStream("ClassLibrary1.last_names.txt")))
               .ToList();

        private static IEnumerable<string> _enumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public static int GenRandomInt(Random random, int max)
        {
            int rRet = random.Next(1, max);
            return rRet;
        }

        public static Student GenerateStudent()
        {
            Student rRet = new Student
            {
                FirstName = FirstNameList[GenRandomInt(rand, FirstNameList.Count)],
                LastName = LastNameList[GenRandomInt(rand, LastNameList.Count)],
            };

            return rRet;
        }
    }
}