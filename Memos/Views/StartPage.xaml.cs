using System;
using System.Collections.Generic;
using Memos.Services;
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

            BindingContext = new MainViewModel(pageService);
        }
    }
}
