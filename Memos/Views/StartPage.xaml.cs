using System;
using System.Collections.Generic;
using Memos.Services;
using Memos.Services.Database;
using Memos.ViewModels;
using Xamarin.Forms;

namespace Memos.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            var pageService = new PageService();
            var database = new SQLiteMethods(DependencyService.Get<ISQLiteDb>());

            BindingContext = new MainViewModel(pageService, database);
        }
    }
}
