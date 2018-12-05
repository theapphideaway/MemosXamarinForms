using System;
using System.Windows.Input;
using Memos.Models;
using Memos.Services;
using Memos.Services.Database;
using Xamarin.Forms;

namespace Memos.ViewModels
{
    public class AddMemoViewModel
    {
        private readonly IPageService _pageService;
        private readonly ISQLiteMethods _sqlite;
        private string _titleEntry;
        private string _contentEditor;
        public  Memo _memo { get; set; }
        public event EventHandler<Memo> MemoAdded;
        public event EventHandler<Memo> MemoUpdated;
        public ICommand SaveMemoCommand { get; set; }

        public AddMemoViewModel(IPageService pageService, ISQLiteMethods sqlite, Memo memo)
        {
            _pageService = pageService;
            _sqlite = sqlite;
            _memo = new Memo
            {
                Id = memo.Id,
                Title = memo.Title,
                Content = memo.Content
            };

            TitleEntry = memo.Title;
            ContentEditor = memo.Content;

            SaveMemoCommand = new Command(() => SaveMemo());
        }

        

        public async void SaveMemo()
        {

            _memo.Title = TitleEntry;
            _memo.Content = ContentEditor;




            var viewModel = new MainViewModel(_pageService, _sqlite);
            //{
            //    SelectedMemo = null
            //};

            if (_memo.Id == 0)
            {
                MemoAdded?.Invoke(this, _memo);
                await _sqlite.AddMemo(_memo);
            }
            else
            {
                await _sqlite.UpdateMemo(_memo);
                MemoUpdated?.Invoke(this, _memo);
            }

            await _pageService.PopAsync();
        }

        public string TitleEntry
        {
            get => _titleEntry;
            set => _titleEntry = value;
        }

        public string ContentEditor
        {
            get => _contentEditor;
            set => _contentEditor = value;
        }

    }
}
