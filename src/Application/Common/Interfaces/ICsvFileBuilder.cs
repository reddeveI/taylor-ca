using CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using CleanArchitecture.Application.WeekDays.Queries.ExportDaySubjects;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);

        byte[] BuildDaySubjectsFile(IEnumerable<DaySubjectFileRecord> records);
    }
}
