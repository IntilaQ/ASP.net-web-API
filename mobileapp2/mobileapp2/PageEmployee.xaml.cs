using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.Client;
using Xamarin.Forms;
using mobileapp2.Models;

namespace mobileapp2
{
    public partial class PageEmployee : ContentPage
    {
        GenericRestClient<Employee> Rest = new GenericRestClient<Employee>();
        public PageEmployee()
        {
            InitializeComponent();
        }

        private async void PostBtn_OnClicked(object sender, EventArgs e)
        {
            Employee E = new Employee();
            E.Name = Txtpostname.Text;
            E.Age = int.Parse(TxtpostAge.Text);
            E.DepartementId = int.Parse(TxtpostdepartementId.Text);
            await  Rest.PostAsync(E);
        }

        private async void PutBtn_OnClicked(object sender, EventArgs e)
        {
            Employee E = new Employee();
            E.Name = Txtputname.Text;
            E.Age = int.Parse(TxtputAge.Text);
            E.DepartementId = int.Parse(TxtputdepartementId.Text);
            E.EmployeeId = int.Parse(TxtputEmployeeId.Text);

            var id = E.EmployeeId;

            await Rest.PutAsync(id, E);
        }

        private  async void DeleteBtn_OnClicked(object sender, EventArgs e)
        {
            var id = int.Parse(TxtDeleteEmployeeId.Text);
                 await Rest.DeleteAsync(id);
        }

        private async void Getbtn_OnClicked(object sender, EventArgs e)
        {
            Mainlist.ItemsSource = await Rest.GetAsync();
        }
    }
}
