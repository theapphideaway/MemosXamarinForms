using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Memos.Models;
using Memos.Services;
using Memos.Views;
using Xamarin.Forms;

namespace Memos.ViewModels
{
    public class MainViewModel
    {
        private IPageService _pageService;
        private ObservableCollection<Memo> _memoList;

        public ICommand AddMemoCommand { get; set; }

        public MainViewModel(IPageService pageService)
        {
            _pageService = pageService;

            MemoList = new ObservableCollection<Memo>();

            AddMemoCommand = new Command( () =>AddMemo());
        }

        public async void AddMemo()
        {
            var viewModel = new AddMemoViewModel(_pageService);

            viewModel.MemoAdded += (source, args) =>
            {
                PopulateList(args);
            };

            await _pageService.PushAsync(new AddMemo(viewModel));
        }

        public void PopulateList(Memo memo)
        {
            MemoList.Add(new Memo
            {
                Title = memo.Title,
                Content = memo.Content
            });
        }

        public ObservableCollection<Memo> MemoList
        {
            get => _memoList;

            set
            {
                _memoList = value;
            }
        }
    }
}
