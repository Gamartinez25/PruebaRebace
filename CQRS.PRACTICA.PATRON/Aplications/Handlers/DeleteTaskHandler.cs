using CQRS.PRACTICA.PATRON.Infrestructura.Commands;
using CQRS.PRACTICA.PATRON.Persistencia;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Aplications.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ContextoTarea _dbContext;
        public DeleteTaskHandler(ContextoTarea dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItem.FindAsync(new object[] { request.taskId }, cancellationToken);
            if (taskItem ==null)
            {
                return false;
            }
            _dbContext.TaskItem.Remove(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}