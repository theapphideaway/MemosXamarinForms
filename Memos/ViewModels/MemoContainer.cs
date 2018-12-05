using System;
using Memos.Models;

namespace Memos.ViewModels
{
    public class MemoContainer: BaseViewModel
    {
        private string _title;
        private string _content;

        public MemoContainer() { }

        public MemoContainer(Memo memo)
        {

        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}
