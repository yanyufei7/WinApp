using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
    public class Student : ReactiveObject
    {
        private string id;
        public string ID
        {
            get => id;
            set => this.RaiseAndSetIfChanged(ref id, value);
        }

        private string stuName;
        public string StuName
        {
            get => stuName;
            set => this.RaiseAndSetIfChanged(ref stuName, value);
        }

        private string age;
        public string Age
        {
            get => age;
            set => this.RaiseAndSetIfChanged(ref age, value);
        }

        private string sex;
        public string Sex
        {
            get => sex;
            set => this.RaiseAndSetIfChanged(ref sex, value);
        }
    }
}
