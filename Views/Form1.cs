using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.ViewModels;

namespace WinApp
{
    public partial class Form1 : Form, IViewFor<SchoolViewModel>
    {
        public Form1()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                //绑定属性
                d(this.Bind(ViewModel, vm => vm.ID, v => v.tb1.Text));
                d(this.Bind(ViewModel, vm => vm.Name, v => v.tb2.Text));
                d(this.Bind(ViewModel, vm => vm.Address, v => v.tb3.Text));
                d(this.Bind(ViewModel, vm => vm.ID, v => v.lb1.Text));
                d(this.Bind(ViewModel, vm => vm.Name, v => v.lb2.Text));
                d(this.Bind(ViewModel, vm => vm.Address, v => v.lb3.Text));
                d(this.Bind(ViewModel, vm => vm.StudentList, v => v.dataGridView1.DataSource));

                //绑定事件
                d(this.BindCommand(ViewModel, vm => vm.NoParaCommand, v => v.btn1));
                d(this.BindCommand(ViewModel, vm => vm.ParaCommand, v => v.btn2,this.WhenAnyValue(v=>v.tb1.Text)));
                d(this.BindCommand(ViewModel, vm => vm.IsCanCommand, v => v.btn3));
                d(this.BindCommand(ViewModel, vm => vm.AddCommand, v => v.btnAdd));
                d(this.BindCommand(ViewModel, vm => vm.UpdateCommand, v => v.btnUpdate));
                d(this.BindCommand(ViewModel, vm => vm.DelCommand, v => v.btnDel));
            });
            ViewModel = new SchoolViewModel();
        }

        public SchoolViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (SchoolViewModel)value; }

        /// <summary>
        /// 修改背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string value=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (value == "3")
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
}
