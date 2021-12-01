using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridExample
{
    public class WorkCalendar
    {
        private readonly List<WorkTask> _tasks = new();
        
        public string AddTask(
            string employeeName, 
            string taskName, 
            DateTime deadLine, 
            string? description, 
            DateTime? dateAssigned = null)
        {
            var workTask = new WorkTask(employeeName, taskName, deadLine, description, dateAssigned);
            _tasks.Add(workTask);
            return workTask.Id;
        }

        public bool IsTaskCompletedOnTime(string id)
        {
            var task = TryGetTask(id);
            if (task == null)
            {
                throw new InvalidOperationException($"invalid parameter {nameof(id)}, value {id}");
            }

            return task.IsCompleted;
        }

        public void CompleteTask(string id, DateTime? completionDate = null)
        {
            var workTask = TryGetTask(id);
            if (workTask != null)
            {
                workTask.CompleteTask(completionDate);
            }
        }

        public void UndoCompleteTask(string id)
        {
            var workTask = TryGetTask(id);
            if (workTask != null)
            {
                workTask.CompletionDate = null;
            }
        }

        public void StartTask(string id)
        {
            var workTask = TryGetTask(id);
            if (workTask != null)
            {
                workTask.StartTask();
            }
        }

        public WorkTask? TryGetTask(string id)
        {
            return _tasks.FirstOrDefault(workTask => workTask.Id == id);
        }
    }
}
