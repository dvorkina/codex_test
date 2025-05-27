using System;
using System.Collections.Generic;

namespace ReceiverControls
{
    /// <summary>
    /// Simple service that stores view model instances and provides them on demand.
    /// It ensures that each view model is created once and reused afterwards.
    /// </summary>
    public class ViewModelService
    {
        private readonly Dictionary<Type, object> _viewModels = new();

        public T GetViewModel<T>() where T : class, new()
        {
            if (!_viewModels.TryGetValue(typeof(T), out var vm))
            {
                vm = new T();
                _viewModels[typeof(T)] = vm;
            }
            return (T)vm;
        }
    }
}
