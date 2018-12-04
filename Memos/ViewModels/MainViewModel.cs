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
        private Memo _selectedMemo;

        public ICommand AddMemoCommand { get; set; }
        public ICommand DeleteMemoCommand { get; set; }
        public ICommand SelectedMemoCommand { get; set; }

        public MainViewModel(IPageService pageService)
        {
            _pageService = pageService;

            MemoList = new ObservableCollection<Memo>();

            AddMemoCommand = new Command( () =>AddMemo());
            DeleteMemoCommand = new Command<Memo>(DeleteMemo);
            SelectedMemoCommand = new Command(MemoSelected);
        }

        public async void AddMemo()
        {
            var memo = new Memo
            {
                Title = null,
                Content = null
            };
            var viewModel = new AddMemoViewModel(_pageService, memo);

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

        public void DeleteMemo(Memo memo)
        {
            MemoList.Remove(memo);
        }

        public async void MemoSelected()
        {
            var memo = SelectedMemo;
            if (memo != null)
            {
                var viewModel = new AddMemoViewModel(_pageService, memo);

                await _pageService.PushAsync(new AddMemo(viewModel));

            }
        }


        //Properties


        public Memo SelectedMemo
        {
            get => _selectedMemo;
            set
            {
                _selectedMemo = value;
                SelectedMemoCommand.Execute(_selectedMemo);
            }
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
