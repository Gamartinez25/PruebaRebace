using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using CQRS.PRACTICA.PATRON.Infrestructura.Commands;
using CQRS.PRACTICA.PATRON.Persistencia;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Aplications.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDTO>
    {
        private readonly ContextoTarea _dbContext;
        public UpdateTaskHandler(ContextoTarea dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItem.FindAsync(new object[] { request.Id }, cancellationToken);
            if (taskItem == null)
            {
                return null;
            }

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new TaskItemDTO { 
                Id= taskItem.Id, 
                Title = taskItem.Title, 
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted, 
                }; 


        }
    }
}
