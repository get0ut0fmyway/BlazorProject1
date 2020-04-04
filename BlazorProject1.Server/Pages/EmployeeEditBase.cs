using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
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

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();
        
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
        
        protected string _countryId = string.Empty;
        protected string _jobCategoryId = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            _countryId = Employee.CountryId.ToString();
            _jobCategoryId = Employee.JobCategoryId.ToString();
        }
    }
}
