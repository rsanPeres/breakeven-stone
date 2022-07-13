﻿using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using BreakevenStoneRepository.Repositories;

namespace BreakevenStoneApplication.Services
{
    public class EmployeeService
    {
        EmployeeRepository _repository;
        public ApplicationContext AppContext { get; set; }
        private IMapper _mapper;


        public EmployeeService(IMapper mapper, ApplicationContext context)
        {
            AppContext = context;
            _mapper = mapper;
        }

        public EmployeeDto EmployeeAdd(EmployeeDto employeeAdd)
        {
            Employee employee = new Employee(employeeAdd.Fuction, employeeAdd.Salary,
                employeeAdd.Password, employeeAdd.FirstName, employeeAdd.LastName,
                employeeAdd.CPF, employeeAdd.Birthday, employeeAdd.Address, employeeAdd.Email);
            if (employee != null)
            {
                _repository.Create(employee);
                return _mapper.Map<EmployeeDto>(employee);
            }
            return null;
        }

        public EmployeeDto EmployeeGetByName(string employeeFind)
        {
            var userf = _repository.Get(employeeFind);
            if (userf != null)
                return _mapper.Map<EmployeeDto>(userf);
            return null;
        }

        public EmployeeDto EmployeeFindByCPF(string emplCPF)
        {
            var employeeFind = _repository.GetByCpf(emplCPF);
            if (employeeFind == null) return null;
            return _mapper.Map<EmployeeDto>(employeeFind);

        }

        public EmployeeDto EmployeeUpdate(string cpf, string function)
        {
            var upEmployee = _repository.Update(cpf, function);
            if (upEmployee != null)
                return _mapper.Map<EmployeeDto>(upEmployee);
            return null;
        }

        public EmployeeDto EmployeeDelbyCpf(string EmployeeDel)
        {
            var del = _repository.Delete(EmployeeDel);
            if (del != null)
                return _mapper.Map<EmployeeDto>(del);
            return null;
        }
    }
}