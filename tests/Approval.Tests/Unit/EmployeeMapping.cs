using System;
using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using Approval.Web;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace Approval.Tests.Unit;

public class EmployeeMapping
{
    private readonly IMapper _mapper;
    
    public EmployeeMapping()
    {
        var config = new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfile>(); });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Employee_To_EmployeeEntity()
    {
        var employee = new Employee(9, "John", "Doe",
            "john.doe@gmail.com", new DateTime(2022, 2, 7),
            2, "IT department");

        var entity = _mapper.Map<EmployeeEntity>(employee);

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
