using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class DataFactory
    {
        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<JobCategory> JobCategories { get; set; }

        public IEnumerable<Benefit> Benefits { get; set; }
        public IEnumerable<EmployeeBenefit> EmployeeBenefits { get; set; }



        public DataFactory()
        {
            InitializeJobCategories();
            InitializeCountries();
            InitializeEmployees();
            InitializeBenefits();
            InitializeEmployeeBenefits();
        }
        private void InitializeJobCategories()
        {
            JobCategories = new List<JobCategory>()
            {
                new JobCategory{JobCategoryId = 1, JobCategoryName = "Pie research"},
                new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
                new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
                new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
                new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
                new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
                new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
                new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"},
                new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"}

            };
        }

        private void InitializeBenefits()
        {

            Benefits = new List<Benefit>()
            {
                new Benefit() { BenefitId = 1, Description = "Health Insurance" },
                new Benefit() { BenefitId = 2, Description = "Paid Time Off" },
                new Benefit() { BenefitId = 3, Description = "Wellness", Premium = true },
                new Benefit() { BenefitId = 4, Description = "Education", Premium = true },
                new Benefit() { BenefitId = 5, Description = "Store Discount" }
            };
        }
        private void InitializeEmployeeBenefits()
        {

            EmployeeBenefits = new List<EmployeeBenefit>()
            {
                new EmployeeBenefit() { BenefitId = 1, EmployeeId = 1},
                new EmployeeBenefit() { BenefitId = 2, EmployeeId = 1},
                new EmployeeBenefit() { BenefitId = 3, EmployeeId = 1},
                new EmployeeBenefit() { BenefitId = 4, EmployeeId = 1},
                new EmployeeBenefit() { BenefitId = 5, EmployeeId = 1},
                new EmployeeBenefit() { BenefitId = 1, EmployeeId = 2},
                new EmployeeBenefit() { BenefitId = 2, EmployeeId = 2},
                new EmployeeBenefit() { BenefitId = 3, EmployeeId = 2},
                new EmployeeBenefit() { BenefitId = 4, EmployeeId = 2},
                
            };
        }
        private void InitializeCountries()
        {
            Countries = new List<Country>
            {
                new Country {CountryId = 1, Name = "Belgium"},
                new Country {CountryId = 2, Name = "Netherlands"},
                new Country {CountryId = 3, Name = "USA"},
                new Country {CountryId = 4, Name = "Japan"},
                new Country {CountryId = 5, Name = "China"},
                new Country {CountryId = 6, Name = "UK"},
                new Country {CountryId = 7, Name = "France"},
                new Country {CountryId = 8, Name = "Brazil"}
            };
        }

        private void InitializeEmployees()
        {
            var e1 = new Employee
            {
                CountryId = 1,
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                EmployeeId = 1,
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Smoker = false,
                Street = "Grote Markt 1",
                Zip = "1000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2015, 3, 1),
                Latitude = 50.8503,
                Longitude = 4.3517
            };

            var e2 = new Employee
            {
                CountryId = 2,
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                EmployeeId = 2,
                FirstName = "Gill",
                LastName = "Cleeren",
                Gender = Gender.Female,
                PhoneNumber = "33999909923",
                Smoker = false,
                Street = "New Street",
                Zip = "2000",
                JobCategoryId = 2,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2017, 12, 24),
                Latitude = 50.8503,
                Longitude = 4.3517
            };
            Employees = new List<Employee> { e1, e2 };
        }
    }
}
