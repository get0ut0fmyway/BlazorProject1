using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.MinValue, JoinedDate = DateTime.MinValue };

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public bool ShowDialog { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.MinValue, JoinedDate = DateTime.MinValue };
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            StateHasChanged();
        }
    }
}
