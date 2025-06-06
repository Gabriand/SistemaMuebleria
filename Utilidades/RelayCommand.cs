using System;
using System.Windows.Input;

namespace MuebleriaPIS.Utilidades
{
    // Versión no genérica para comandos simples
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    // Versión genérica para comandos que requieren un parámetro de tipo T
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
            {
                return false;
            }

            // Verifica si el parámetro puede convertirse al tipo T
            if (parameter == null || parameter is T)
            {
                return _canExecute == null || _canExecute((T)parameter);
            }

            return false; // No puede ejecutarse si el tipo no es compatible
        }

        public void Execute(object parameter)
        {
            if (parameter is T castParameter)
            {
                _execute(castParameter);
            }
            else if (parameter == null && typeof(T).IsValueType)
            {
                throw new InvalidOperationException($"El parámetro no puede ser nulo para el tipo {typeof(T).Name}");
            }
            else
            {
                throw new InvalidCastException($"No se puede convertir el parámetro de tipo {parameter?.GetType().Name} al tipo {typeof(T).Name}.");
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
