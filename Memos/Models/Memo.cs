﻿using System;
using Memos.ViewModels;
using SQLite;

namespace Memos.Models
{
    public class Memo: BaseViewModel
    {
        private int _id;
        private string _title;
        private string _content;

        [PrimaryKey, AutoIncrement]
        public int Id 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
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
