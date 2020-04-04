using BethanysPieShopHRM.Shared;
using BlazorProject1.Server.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }
    }
}
