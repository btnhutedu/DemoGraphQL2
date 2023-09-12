using DemoGraphQL2.Model;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace DemoGraphQL2.GraphQLDataAccess
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Department>("DepartmentCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentUpdate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Department>("DepartmentUpdated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeUpdate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Employee>("EmployeeUpdated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Employee>("EmployeeCreated", cancellationToken);
        }
    }
}
