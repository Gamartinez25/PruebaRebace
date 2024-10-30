using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using CQRS.PRACTICA.PATRON.Domain;
using CQRS.PRACTICA.PATRON.Infrestructura.Commands;
using CQRS.PRACTICA.PATRON.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.PRACTICA.PATRON.Aplications.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand,TaskItemDTO>
    {
        private readonly ContextoTarea _dbContext;
    public CreateTaskHandler(ContextoTarea dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<TaskItemDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
            };
            _dbContext.TaskItem.Add(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);


        return new TaskItemDTO {

            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsCompleted = taskItem.IsCompleted,

        };

        }
    }
}
