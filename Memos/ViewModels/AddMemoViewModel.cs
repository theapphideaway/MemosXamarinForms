using System;
using System.Windows.Input;
using Memos.Models;
using Memos.Services;
using Xamarin.Forms;

namespace Memos.ViewModels
{
    public class AddMemoViewModel
    {
        private IPageService _pageService;
        private string _titleEntry;
        private string _contentEditor;

        public event EventHandler<Memo> MemoAdded;
        public ICommand SaveMemoCommand { get; set; }

        public AddMemoViewModel(IPageService pageService, Memo memo)
        {
            _pageService = pageService;

            TitleEntry = memo.Title;
            ContentEditor = memo.Content;

            SaveMemoCommand = new Command(() => SaveMemo());
        }

        

        public async void SaveMemo()
        {
            var memo = new Memo
            {
                Title = TitleEntry,
                Content = ContentEditor
            };

            MemoAdded?.Invoke(this, memo);

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
