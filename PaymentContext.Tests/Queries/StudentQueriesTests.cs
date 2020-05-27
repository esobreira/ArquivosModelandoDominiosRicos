using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red // Green // Refactor
        private IList<Student> _students = new List<Student>();

        public StudentQueriesTests()
        {
            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("11111111111" + i.ToString(), EDocumentType.CPF),
                    new EMail(i.ToString() + "@eberton.com")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("123456789");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("111111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(true, studn);
        }
    }
}
