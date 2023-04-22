using System;
using System.Collections.Generic;
using System.Linq;
using Reactivity;
using UnityEngine.Events;

namespace Subscription
{
    public class SubscriptionAggregator
    {
        private readonly Dictionary<object, List<(Delegate OriginalHandler, Action UnsubscribeHandler)>>
            _subscriptions = new();

        public void ListenEvent(UnityEvent caller, UnityAction handler, bool invokeImmediately = false)
        {
            if (caller == null)
                throw new Exception("Attempted to pass null object for event caller");
            if (handler == null)
                throw new Exception("Attempted to pass null handler for event");

            caller.AddListener(handler);
            AddSubscription(caller, handler, () => caller.RemoveListener(handler));
            if (invokeImmediately) handler.Invoke();
        }

        public void ListenEvent<TPropertyType>(IReactiveProperty<TPropertyType> caller, EventHandler<GenericEventArg<TPropertyType>> handler,
            bool invokeImmediately = false)
        {
            if (caller == null)
                throw new Exception("Attempted to pass null object for event caller");
            if (handler == null)
                throw new Exception("Attempted to pass null handler for event");

            caller.OnValueChanged += handler;
            AddSubscription(caller, handler, () => caller.OnValueChanged -= handler);
            if(invokeImmediately) handler.Invoke(caller, new GenericEventArg<TPropertyType>(caller.Value));
        }

        private void AddSubscription(object notifyContainer, Delegate handler, Action unsubscribeAction)
        {
            if (!_subscriptions.ContainsKey(notifyContainer))
                _subscriptions[notifyContainer] = new List<(Delegate, Action)>();

            _subscriptions[notifyContainer].Add((handler, unsubscribeAction));
        }

        public void UnlistenEvent(UnityEvent caller, UnityAction handler)
        {
            RemoveSubscription(caller, handler);
        }

        private void RemoveSubscription(object caller, Delegate handler)
        {
            if (!_subscriptions.TryGetValue(caller, out var propertySubscriptions)) return;
            for (var i = propertySubscriptions.Count - 1; i > -1; i--)
            {
                var currentSubscription = propertySubscriptions[i];

                if (currentSubscription.OriginalHandler != handler) continue;

                currentSubscription.UnsubscribeHandler();
                propertySubscriptions.RemoveAt(i);
            }
        }

        public void Unsubscribe()
        {
            foreach (var subs in _subscriptions.SelectMany(kvp => kvp.Value)) subs.UnsubscribeHandler.Invoke();

            _subscriptions.Clear();
        }
    }
}