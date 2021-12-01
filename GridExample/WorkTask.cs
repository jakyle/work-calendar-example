using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridExample
{
    public enum WorkTaskStatus
    {
        Assigned,
        InProgress,
        IsCompleted
    }

    public class WorkTask
    {
        private WorkTaskStatus _status = WorkTaskStatus.Assigned;
        private DateTime? _taskStarted = null;

        public WorkTask(
            string employeeName, 
            string name, 
            DateTime deadLine, 
            string? description, 
            DateTime? dateAssigned)
        {
            EmployeeName = employeeName;
            Name = name;
            DeadLine = deadLine;
            Description = description;
            
            if (dateAssigned != null)
            {
                DateAssigned = dateAssigned.Value;
            }
            else
            {
                DateAssigned = DateTime.UtcNow;
            }
        }

        public string EmployeeName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? TaskStarted => this._taskStarted;
        public DateTime DateAssigned { get; set; }
        public DateTime DeadLine { get; set; }
        public string Id { get; } = Guid.NewGuid().ToString();
        public WorkTaskStatus Status => this._status;
        public bool IsCompleted => this._status == WorkTaskStatus.IsCompleted;
        public bool IsLate => this.CompletionDate.HasValue && this.CompletionDate.Value < this.DeadLine;

        public void StartTask()
        {
            this._status = WorkTaskStatus.InProgress;
            this._taskStarted = DateTime.UtcNow;
        }

        public void CompleteTask(DateTime? completionDate)
        {
            if (completionDate != null)
            {
                this.CompletionDate = completionDate;
            }

            this.CompletionDate = DateTime.Now;
            this._status = WorkTaskStatus.IsCompleted;
        }
    }
}
