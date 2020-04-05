using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();
        
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
        
        protected string _countryId = string.Empty;
        protected string _jobCategoryId = string.Empty;

        protected string _message = string.Empty;
        protected string _statusClass = string.Empty;
        protected bool _saved;

        protected override async Task OnInitializedAsync()
        {
            _saved = false;

            //Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);
            if (employeeId == 0) // new employee
            {
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now };
            }
            else // existing employee
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            _countryId = Employee.CountryId.ToString();
            _jobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Employee.CountryId = int.Parse(_countryId);
            Employee.JobCategoryId = int.Parse(_jobCategoryId);

            if (Employee.EmployeeId == 0) // new employee
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    _statusClass = "alert-sucess";
                    _message = "New employee added successfully.";
                    _saved = true;
                }
                else
                {
                    _statusClass = "alert-danger";
                    _message = "Something went wrong adding the new employee.  Please try again.";
                    _saved = false;
                }
            }
            else // existing employee
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                _statusClass = "alert-sucess";
                _message = "Employee updated successfully.";
                _saved = true;

            }
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            _statusClass = "alert-success";
            _message = "Deleted successfully";

            _saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
