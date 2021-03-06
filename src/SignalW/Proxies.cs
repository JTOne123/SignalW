// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;
using System.Threading.Tasks;

namespace Spreads.SignalW
{
    public class UserProxy<THub> : IClientProxy
    {
        private readonly string _userId;
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public UserProxy(HubLifetimeManager<THub> lifetimeManager, string userId)
        {
            _lifetimeManager = lifetimeManager;
            _userId = userId;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeUserAsync(_userId, payload);
        }
    }

    public class ExceptUserProxy<THub> : IClientProxy
    {
        private readonly string _userId;
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public ExceptUserProxy(HubLifetimeManager<THub> lifetimeManager, string userId)
        {
            _lifetimeManager = lifetimeManager;
            _userId = userId;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeExceptUserAsync(_userId, payload);
        }
    }

    public class GroupProxy<THub> : IClientProxy
    {
        private readonly string _groupName;
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public GroupProxy(HubLifetimeManager<THub> lifetimeManager, string groupName)
        {
            _lifetimeManager = lifetimeManager;
            _groupName = groupName;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeGroupAsync(_groupName, payload);
        }
    }

    public class AllClientProxy<THub> : IClientProxy
    {
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public AllClientProxy(HubLifetimeManager<THub> lifetimeManager)
        {
            _lifetimeManager = lifetimeManager;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeAllAsync(payload);
        }
    }

    public class SingleClientProxy<THub> : IClientProxy
    {
        private readonly string _connectionId;
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public SingleClientProxy(HubLifetimeManager<THub> lifetimeManager, string connectionId)
        {
            _lifetimeManager = lifetimeManager;
            _connectionId = connectionId;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeConnectionAsync(_connectionId, payload);
        }
    }

    public class ExceptClientProxy<THub> : IClientProxy
    {
        private readonly string _connectionId;
        private readonly HubLifetimeManager<THub> _lifetimeManager;

        public ExceptClientProxy(HubLifetimeManager<THub> lifetimeManager, string connectionId)
        {
            _lifetimeManager = lifetimeManager;
            _connectionId = connectionId;
        }

        public ValueTask SendAsync(MemoryStream payload)
        {
            return _lifetimeManager.InvokeExceptConnectionAsync(_connectionId, payload);
        }
    }
}
