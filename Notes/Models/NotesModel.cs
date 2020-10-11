using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    class NotesModel : INotifyPropertyChanged
    {
        [JsonProperty(PropertyName ="Дата создания")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool _isDone;
        private string _text;



        [JsonProperty(PropertyName = "Выполнено ли")]
        public bool isDone
        {
            get { return _isDone; }
            set
            {
                if(_isDone == value)
                {
                    return;
                }
                _isDone = value;
                OnPropertyChanged("isDone");
            }
        }
        [JsonProperty(PropertyName = "Текст сообщения")]
        public string Text
        {
            get { return _text; }
            set
            {
                if(_text == value)
                {
                    return;
                }
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));          
        }
    }
}
