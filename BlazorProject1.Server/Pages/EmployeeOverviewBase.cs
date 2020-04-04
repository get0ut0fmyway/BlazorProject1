using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
		protected override Task OnInitializedAsync()
		{
			return base.OnInitializedAsync();
		}

		public IEnumerable<Employee> Employees { get; set; }
	}
}
