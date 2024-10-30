using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using CQRS.PRACTICA.PATRON.Infrestructura.Queries;
using CQRS.PRACTICA.PATRON.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.PRACTICA.PATRON.Aplications.Handlers
{
    public class  GetAllTaskHandler: IRequestHandler<GetAllTaskQuery,IEnumerable<TaskItemDTO>>
    {
        private readonly ContextoTarea _dbContext;
        public GetAllTaskHandler(ContextoTarea dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskItemDTO>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.TaskItem.ToListAsync(cancellationToken);
            return tasks.Select(task => new TaskItemDTO
            {
                Id = task.Id, 
                Title = task.Title, 
                Description = task.Description, 
                IsCompleted  = task.IsCompleted, 

            });


        }
    }
}
