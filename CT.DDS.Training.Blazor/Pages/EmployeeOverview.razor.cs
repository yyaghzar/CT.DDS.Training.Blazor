using BethanysPieShopHRM.Shared;
using CT.DDS.Training.Blazor.Components;
using CT.DDS.Training.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.Blazor.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        [Inject]
        public DataFactory DataFactory { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }


        public AddEmployeeDialogBase AddEmployeeDialog { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();

        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.ShowDialog = true;

        }
        
        public async Task AddEmployeeDialog_onDialogClose()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
            StateHasChanged();
        }
    }
}
