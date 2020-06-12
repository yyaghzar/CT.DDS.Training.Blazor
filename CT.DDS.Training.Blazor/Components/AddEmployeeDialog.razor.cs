using BethanysPieShopHRM.Shared;
using CT.DDS.Training.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.Blazor.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public bool ShowDialog { get; set; }


        public void Close()
        {

            ShowDialog = false;
            StateHasChanged();
            

        }

        public void Show()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            ShowDialog = true;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {

            await EmployeeDataService.AddEmployee(Employee);
            await CloseEventCallback.InvokeAsync(false);
            ShowDialog = false;
            StateHasChanged();

        }
    }
}
