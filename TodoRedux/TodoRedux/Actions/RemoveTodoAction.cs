using System;
using Redux;

namespace TodoRedux.Actions
{
    internal class RemoveTodoAction : IAction
    {
        public Guid Id { get; internal set; }
    }
}