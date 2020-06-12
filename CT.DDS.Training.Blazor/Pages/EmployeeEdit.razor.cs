using BethanysPieShopHRM.Shared;
using CT.DDS.Training.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.Blazor.Pages
{
    public class EmployeeEditBase: ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public IEnumerable<Country> Countries { get; set; } = new List<Country>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        [Inject]
        public IEmployeeDataService EmployeeDataService  { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        protected string CountryId = string.Empty;
        protected string JobCategoryId  = string.Empty;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async  Task OnInitializedAsync()
        {
            Saved = false;
            Countries = await CountryDataService.GetAllCountries();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();

            int.TryParse(EmployeeId, out var employeeId);
            if (employeeId == 0)
                Employee = new Employee { CountryId = 1, JobCategoryId = 1 , BirthDate = DateTime.Now};
            else
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();

            

        }

        protected async Task HandleValidSubmit() {

            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);

            if (Employee.EmployeeId == 0)
            {
                var employeeAdded = await EmployeeDataService.AddEmployee(Employee);
                if (employeeAdded != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "New employee added successfully";
                Saved = true;
            }
        }

        protected async Task DeleteEmployee() {

            await EmployeeDataService.DeleteEmployee(Employee);
            StatusClass = "alert-success";
            Message = "Employee deleted";
            Saved = true;
        }

        protected void NavigateToOverview() {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
