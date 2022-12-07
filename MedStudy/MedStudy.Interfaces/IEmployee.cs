using System;
using MedStudy.Model;


namespace MedStudy.Interfaces
{
    public interface IEmployee
    {
        Task<List<EmployeeResponseModel>> SearchEmployee(EmployeeRequestModel request);

        Task<List<StateModel>> GetStates();
    }
}
