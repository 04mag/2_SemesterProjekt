using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anden_SemesterProjekt.Shared.Validation;

namespace NunitTestProject
{
    public class NunitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("mail@mail.dk", true)]
        [TestCase("test.mail@mail.dk", true)]
        [TestCase("test.mail@test.mail.dk", true)]
        [TestCase("mail@mail.co.uk", true)]
        [TestCase("mail@mail", false)]
        [TestCase("mailmail.dk", false)]
        [TestCase("mailmail", false)]
        [TestCase("mail@mail..dk", false)]
        [TestCase("mail@mail.d", false)]
        public void EmailIsValidTest(string input, bool expectedResult)
        {
            bool result = SLValidator.EmailIsValid(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("22345678", true)]
        //False fordi nummer starter med 1
        [TestCase("12345678", false)]
        [TestCase("7654321", false)]
        [TestCase("987654321", false)]
        [TestCase("2345678a", false)]
        //False fordi nummer starter med 0
        [TestCase("02345678 ", false)]
        public void PhoneIsValidTest(string input, bool expectedResult)
        {
            bool result = SLValidator.PhoneNumberIsValid(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("test", 1, 8, true)]
        [TestCase("12345678", 8, 8, true)]
        [TestCase("12345678", 1, 3, false)]
        [TestCase("12345678", 9, 10, false)]
        //Hvis man sætter min større end max
        [TestCase("altid false", 10, 1, false)]
        public void StringLenghtTest(string input, int min, int max, bool expectedResult)
        {
            bool result = SLValidator.StringLenght(input, min, max);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
