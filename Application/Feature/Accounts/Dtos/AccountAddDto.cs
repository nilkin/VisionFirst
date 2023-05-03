﻿using Application.Feature.Employees.Dtos;
using Application.Feature.Positions.Dtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Accounts.Dtos
{
    public class AccountAddDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? EmployeeId { get; set; }
        public Role? Role { get; set; }
        public IList<EmployeeListDto>? Employees { get; set; }
    }
}
