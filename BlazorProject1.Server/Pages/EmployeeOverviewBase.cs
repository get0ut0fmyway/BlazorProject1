using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Components;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
		[Inject]
		private IEmployeeDataService EmployeeDataService { get; set; }

		public IEnumerable<Employee> Employees { get; set; }

		protected AddEmployeeDialogBase AddEmployeeDialog { get; set; } 

		protected void QuickAddEmployee()
		{
			AddEmployeeDialog.Show();
		}

		protected override async Task OnInitializedAsync()
		{
			Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
		}

	}
}
