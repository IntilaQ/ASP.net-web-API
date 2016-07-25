using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobileapp2.Models;
using RestClient.Client;
using Xamarin.Forms;

namespace mobileapp2
{
    public partial class PageDepartement : ContentPage
    {

        public GenericRestClient<Departement> Rest =new GenericRestClient<Departement>();
        public PageDepartement()
        {
            InitializeComponent();
        }

        private async  void PostBtn_OnClicked(object sender, EventArgs e)
        {
            Departement D = new Departement();
            D.Name = Txtpostname.Text;

            await Rest.PostAsync(D);
        }

        private async void PutBtn_OnClicked(object sender, EventArgs e)
        {
            Departement D = new Departement();
            D.Name = Txtputname.Text;
            D.DepartementId = int.Parse(TxtputDepartementId.Text);

            var id = D.DepartementId;
            await Rest.PutAsync(id,D);
        }

        private  async void DeleteBtn_OnClicked(object sender, EventArgs e)
        {
            var id = int.Parse(TxtDeleteDepartementId.Text);

            await Rest.DeleteAsync(id);
        }

        private async void Getbtn_OnClicked(object sender, EventArgs e)
        {
            Mainlist.ItemsSource = await Rest.GetAsync();
        }
    }
}
