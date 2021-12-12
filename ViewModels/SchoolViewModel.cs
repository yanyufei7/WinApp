using log4net;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.ViewModels
{
    public class SchoolViewModel:ReactiveObject
    {
        ILog log = log4net.LogManager.GetLogger("loginfo");

        #region 字段属性
        private string id;
        public string ID
        {
            get => id;
            set => this.RaiseAndSetIfChanged(ref id,value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        private string address;
        public string Address
        {
            get => address;
            set => this.RaiseAndSetIfChanged(ref address, value);
        }

        private BindingList<Student> studentList;
        public BindingList<Student> StudentList
        {
            get => studentList;
            set => this.RaiseAndSetIfChanged(ref studentList, value);
        }

        #endregion

        #region 命令
        public ReactiveCommand<Unit, Unit> NoParaCommand { get; }
        public ReactiveCommand<string, Unit> ParaCommand { get; }

        public ReactiveCommand<Unit, Unit> IsCanCommand { get; }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }

        public ReactiveCommand<Unit, Unit> UpdateCommand { get; }

        public ReactiveCommand<Unit, Unit> DelCommand { get; }
        #endregion

        #region 构造函数
        public SchoolViewModel()
        {
            NoParaCommand = ReactiveCommand.Create(NoParaFun);
            ParaCommand = ReactiveCommand.Create<string>(ParaFun);
            IsCanCommand= ReactiveCommand.Create(IsCanFun, this.WhenAnyValue(vm => vm.Address).Select(s => string.IsNullOrEmpty(s) == false));
            AddCommand = ReactiveCommand.Create(AddFun);
            UpdateCommand = ReactiveCommand.Create(UpdateFun);
            DelCommand= ReactiveCommand.Create(DelFun);

            StudentList = new BindingList<Student>() { 
                new Student() { ID = "1", StuName = "1", Age = "1", Sex = "1" },
                new Student() { ID = "2", StuName = "2", Age = "2", Sex = "2" }
            };
        }

        #endregion

        #region 方法
        private void NoParaFun()
        {
            MessageBox.Show("NoParaFun");
        }

        private void ParaFun(string para)
        {
            MessageBox.Show("ParaFun"+para);
        }

        private void IsCanFun()
        {
            MessageBox.Show("IsCanFun");
        }

        private void AddFun()
        {
            StudentList.Add(new Student() { ID = "3", StuName = "3", Age = "3", Sex = "3" });
            log.Info("新增成功");
        }

        private void UpdateFun()
        {
            var model=StudentList.FirstOrDefault(s => s.ID == "1");
            if (model != null)
            {
                model.Age = "3";
            }
        }

        private void DelFun()
        {
            var model = StudentList.FirstOrDefault(s => s.ID == "3");
            StudentList.Remove(model);
        }
        #endregion
    }
}
