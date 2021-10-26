using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PatternSample
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }



        class WebService : Service
    {
        public WebService(string n) : base(n) { }
        public override Command Create()
        {
            var cmd = new Command(o => { MessageBox.Show(Name + o.ToString()); });
            cmd.Execute("1");
            return cmd;
            
        }
    }

    class Desktop : Service
    {
        
        public Desktop(string n) : base(n) { }
        public override Command Create()
        {
            var cmd = new Command(o => { MessageBox.Show(Name + o.ToString()); });
            cmd.Execute("1");
            return cmd;
        }
    }

    abstract class Service
    {
        public Service (string _name)
        {
            Name = _name;
        }
        public string Name { get; set; }
        abstract public Command Create();
    }


}
