using MedStudy.ApplicationServices;
using MedStudy.Model;

namespace MedStudy.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetStates()
        {
            var response = await new EmployeeService().GetStates();
            Assert.IsNotNull(response);
            Assert.Pass();
        }

        [Test]
        public async Task GetEmployees()
        {
            EmployeeRequestModel request = new EmployeeRequestModel();
            request.FirstName = String.Empty;
            request.LastName = String.Empty;
            request.State = String.Empty;
            request.Year = String.Empty;

            var response = await new EmployeeService().SearchEmployee(request);
            Assert.IsNotNull(response);
            Assert.Pass();
        }

        [Test]
        public async Task GetEmployeesByYear()
        {
            EmployeeRequestModel request = new EmployeeRequestModel();
            request.FirstName = "John";
            request.LastName = String.Empty;
            request.State = String.Empty;
            request.Year = "2022";

            var response = await new EmployeeService().SearchEmployee(request);
            Assert.IsNotNull(response);
            Assert.Pass();
        }


    }
}