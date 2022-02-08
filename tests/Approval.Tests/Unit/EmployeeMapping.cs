using System;
using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using FluentAssertions;
using Xunit;

namespace Approval.Tests.Unit
{
    public class EmployeeMapping : MappingTests
    {
        [Fact]
        public void Should_Map_Employee_To_EmployeeEntity()
        {
            var employee = new Employee(9, "John", "Doe",
                "john.doe@gmail.com", new DateTime(2022, 2, 7),
                2, "IT department");

            var entity = Mapper.Map<EmployeeEntity>(employee);

            entity.Should().NotBeNull();
            entity.Id.Should().Be(employee.EmployeeId);
            entity.FirstName.Should().Be(employee.FirstName);
            entity.LastName.Should().Be(employee.LastName);
            entity.Email.Should().Be(employee.Email);
            entity.DateOfBirth.ToDateTime(TimeOnly.MinValue).Should().Be(employee.DateOfBirth.Date);
            entity.DepartmentId.Should().Be(employee.DepartmentId);
            entity.Department.Should().Be(employee.Department);
        }
    }
}
