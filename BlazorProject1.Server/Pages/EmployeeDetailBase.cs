using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Pages
{
    public class EmployeeDetailBase : ComponentBase
	{
		[Parameter]
		public string EmployeeId { get; set; }

		[Inject]
		private IEmployeeDataService EmployeeDataService { get; set; }

		public Employee Employee { get; set; } = new Employee();

		protected override async Task OnInitializedAsync()
		{

			Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
		}

	}
}
