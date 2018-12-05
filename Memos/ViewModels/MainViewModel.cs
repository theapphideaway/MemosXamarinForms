using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Memos.Models;
using Memos.Services;
using Memos.Services.Database;
using Memos.Views;
using Xamarin.Forms;

namespace Memos.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly ISQLiteMethods _sqlite;
        private ObservableCollection<Memo> _memoList;
        private Memo _selectedMemo;

        public ICommand AddMemoCommand { get; set; }
        public ICommand DeleteMemoCommand { get; set; }
        public ICommand SelectedMemoCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }

        public MainViewModel(IPageService pageService, ISQLiteMethods sqlite)
        {
            _pageService = pageService;
            _sqlite = sqlite;

            MemoList = new ObservableCollection<Memo>();

            AddMemoCommand = new Command(AddMemo);
            DeleteMemoCommand = new Command<Memo>(DeleteMemo);
            SelectedMemoCommand = new Command(MemoSelected);
            LoadDataCommand = new Command(LoadData);

            LoadDataCommand.Execute(null);
        }

        public async void AddMemo()
        {
            var memo = new Memo
            {
                Title = null,
                Content = null
            };
            var viewModel = new AddMemoViewModel(_pageService, _sqlite, memo);

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

        public async void DeleteMemo(Memo memo)
        {
            MemoList.Remove(memo);

            var deletedMemo = await _sqlite.GetMemo(memo.Id);
            await _sqlite.DeleteMemo(deletedMemo);
        }

        public async void LoadData()
        {
            var memos = await _sqlite.GetMemoAsync();
            foreach (var memo in memos)
            {
                MemoList.Add(new Memo
                {
                    Title = memo.Title,
                    Content = memo.Content,
                    Id = memo.Id
                });
            }
        }

        public async void MemoSelected()
        {
            var memo = SelectedMemo;
            if (memo != null)
            {
                var viewModel = new AddMemoViewModel(_pageService, _sqlite, memo);

                viewModel.MemoUpdated += (source, updatedMemo) =>
                {
                    memo.Id = updatedMemo.Id;
                    memo.Title = updatedMemo.Title;
                    memo.Content = updatedMemo.Content;

                    var list = MemoList;
                    // LoadDataCommand.Execute(null);
                    var foo = SelectedMemo;
                };


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
                OnPropertyChanged();
                SelectedMemoCommand.Execute(_selectedMemo);
            }
        }

        public ObservableCollection<Memo> MemoList
        {
            get => _memoList;

            set
            {
                _memoList = value;
                OnPropertyChanged("MemoList");
            }
        }
    }
}
