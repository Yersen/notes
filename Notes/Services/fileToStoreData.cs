﻿using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services
{
    class fileToStoreData
    {
        private readonly string PATH;
        public fileToStoreData(string path)
        {
            PATH = path;
        }
        public BindingList<NotesModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<NotesModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NotesModel>>(fileText);
            }
        }
        public void SaveData(object notesDataList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {

                string output = JsonConvert.SerializeObject(notesDataList);
                writer.Write(output);
            }
        }
    }
}
