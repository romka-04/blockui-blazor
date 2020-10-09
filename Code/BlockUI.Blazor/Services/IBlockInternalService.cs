using System;
using System.Collections.Generic;

namespace BlockUI.Blazor.Services
{
    public interface IBlockInternalService
    {
        void Add(string name, string elementId);

        bool TryGetValue(string name, out string elementId);
    }

    class BlockInternalService 
        : Dictionary<string, string>
        , IBlockInternalService
    {
        public new void Add(string name, string elementId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name of component is mandatory.", nameof(name));

            base.Add(name, elementId);
        }
    }
}