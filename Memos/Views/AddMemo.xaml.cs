using System;
using System.Collections.Generic;
using Memos.ViewModels;
using Xamarin.Forms;

namespace Memos.Views
{
    public partial class AddMemo : ContentPage
    {
        public AddMemo(AddMemoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
