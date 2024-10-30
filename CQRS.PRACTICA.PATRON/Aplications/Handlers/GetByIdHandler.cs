using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using CQRS.PRACTICA.PATRON.Infrestructura.Queries;
using CQRS.PRACTICA.PATRON.Persistencia;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Aplications.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDTO>
    {
        private readonly ContextoTarea _dbContext;
        public GetByIdHandler(ContextoTarea dbContext){
            _dbContext = dbContext; 

        }
        public async Task<TaskItemDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItem.FindAsync(new object[] { request.taskId }, cancellationToken);
            if (taskItem == null) { return null; }
            return new TaskItemDTO
            {
                Id = taskItem.Id,
                Description = taskItem.Description,
                Title = taskItem.Title,
                IsCompleted = taskItem.IsCompleted,
            };
           
        }
    }
}
