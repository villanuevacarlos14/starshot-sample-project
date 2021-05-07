using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Starshot.Data;
using Starshot.Data.Models;
using Starshot.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LinqKit;

namespace Starshot.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetById(int id);
        Task<IEnumerable<EmployeeDTO>> Get(string search, int active);
        Task<int> Save(EmployeeDTO employee);
        Task Delete(int Id);
        Task<AttendanceDTO> Attendance(DateTime date);
        Task<EmployeeAttendanceDTO> TimeIn(int id, DateTime date);
        Task<EmployeeAttendanceDTO> TimeOut(int id, DateTime date);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly StarshotDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(StarshotDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeAttendanceDTO> TimeOut(int id, DateTime date)
        {


            var data = await this._dbContext.EmployeeAttendances.Include(x => x.Employee).Where(x => x.ClockIn.HasValue
               && x.ClockIn.Value.Date == date.Date
               && !x.ClockOut.HasValue
               && x.EmployeeId == id).FirstOrDefaultAsync();

            if (data != null)
            {
                var currentDate = DateTime.Now;
                data.ClockOut = new DateTime(date.Year, date.Month, date.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);
                await this._dbContext.SaveChangesAsync();

                return this._mapper.Map<EmployeeAttendanceDTO>(data);
            }

            return null;
        }

        public async Task<EmployeeAttendanceDTO> TimeIn(int id, DateTime date)
        {
            var data = await this._dbContext.EmployeeAttendances.Include(x => x.Employee).Where(x => x.ClockIn.HasValue && x.ClockIn.Value.Date == date.Date
              && x.EmployeeId == id).FirstOrDefaultAsync();

            if (data == null)
            {
                var currentDate = DateTime.Now;
                var req = new EmployeeAttendance()
                {
                    ClockIn = new DateTime(date.Year, date.Month, date.Day, currentDate.Hour, currentDate.Minute, currentDate.Second),
                    EmployeeId = id
                };
                this._dbContext.EmployeeAttendances.Add(req);
                await this._dbContext.SaveChangesAsync();

                req.Employee = await this._dbContext.Employees.FirstOrDefaultAsync(x => x.Id == req.EmployeeId);
                return this._mapper.Map<EmployeeAttendanceDTO>(req);
            }

            return null;
        }

        public async Task<AttendanceDTO> Attendance(DateTime date)
        {
            var predicate = PredicateBuilder.New<EmployeeAttendance>();
            predicate.And(x => x.ClockIn.HasValue ? x.ClockIn.Value.Date == date.Date : false);
            predicate.And(x => x.ClockOut.HasValue ? x.ClockOut.Value.Date == date.Date : true);
            var current = this._dbContext.EmployeeAttendances.Include(x => x.Employee).Where(predicate);

            var employeesNotLoggedIn = await this._dbContext.Employees.Where(x => !current.Any(r => r.EmployeeId == x.Id)).ToListAsync();
            var timeInEmployees = await current.Where(x => x.ClockIn.HasValue && !x.ClockOut.HasValue).ToListAsync();
            var timeInAndOutEmployees = await current.Where(x => x.ClockIn.HasValue && x.ClockOut.HasValue).ToListAsync();

            return new AttendanceDTO()
            {
                date = date,
                Employees = this._mapper.Map<IEnumerable<EmployeeDTO>>(employeesNotLoggedIn),
                TimedInEmployees = this._mapper.Map<IEnumerable<EmployeeAttendanceDTO>>(timeInEmployees),
                TimeOutEmployees = this._mapper.Map<IEnumerable<EmployeeAttendanceDTO>>(timeInAndOutEmployees),
            };
        }

        public async Task Delete(int Id)
        {
            var existing = await this._dbContext.Employees.SingleOrDefaultAsync(x => x.Id == Id);
            if (existing != null)
            {
                this._dbContext.Employees.Remove(existing);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> Get(string search, int active)
        {
            var predicate = PredicateBuilder.New<Employee>(true);

            if (!string.IsNullOrEmpty(search))
            {
                predicate = predicate.And(x => x.Name.ToLower().Contains(search.ToLower()));
            }


            switch (active)
            {
                case 0:

                    break;
                case 1:
                    predicate = predicate.And(x => x.Active);
                    break;
                case 2:
                    predicate = predicate.And(x => !x.Active);
                    break;
            }


            var resp = await _dbContext.Employees
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<EmployeeDTO>>(resp);
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Employee, EmployeeDTO>(emp);
        }

        public async Task<int> Save(EmployeeDTO employee)
        {
            if (employee.Id == 0)
            {
                var emp = _mapper.Map<EmployeeDTO, Employee>(employee);
                await this._dbContext.Employees.AddAsync(emp);
                await this._dbContext.SaveChangesAsync();
                return emp.Id;
            }
            else
            {
                var existing = await this._dbContext.Employees.SingleOrDefaultAsync(x => x.Id == employee.Id);
                existing.Name = employee.Name;
                existing.Active = employee.Active;

                await this._dbContext.SaveChangesAsync();

                return existing.Id;
            }


        }


    }
}
