using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BlockUI.Blazor.Services
{
    internal interface IIdentityPool
    {
        /// <summary>
        /// Adds a unique ID of the DOM element that is used to block screen.
        /// </summary>
        /// <param name="uniqueId">The DOC element ID.</param>
        void Add(string uniqueId);
        /// <summary>
        /// Creates new unique ID of the DOM element.
        /// </summary>
        /// <returns></returns>
        string CreateNew();
        /// <summary>
        /// Returns all ID elements from cache.
        /// </summary>
        /// <returns></returns>
        IReadOnlyCollection<string> GetAllIdentities();
        /// <summary>
        /// Removes all elements from the Pool.
        /// </summary>
        void Clear();
    }

    internal class IdentityPool
        : IIdentityPool
    {
        private readonly ConcurrentBag<string> _cache = new ConcurrentBag<string>();

        public void Add(string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
                throw new ArgumentNullException(nameof(uniqueId));
            _cache.Add(uniqueId);
        }

        public string CreateNew()
        {
            var id = $"BlockUI-{Guid.NewGuid():N}";
            Add(id);
            return id;
        }

        public IReadOnlyCollection<string> GetAllIdentities()
        {
            return _cache;
        }

        public void Clear()
        {
            // NET Standard 2.1 has method Clear() but we don't
            while (!_cache.IsEmpty)
            {
                _cache.TryTake(out string _);
            }
        }
    }
}