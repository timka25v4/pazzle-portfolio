using practice.Responses.Course;
using practice.Responses.Direction;
using practice.Responses.Project;

namespace practice.Responses.Group;

public class GroupResponse : BaseResponse
{
    /// <summary>
    /// Модель направления
    /// </summary>
    public DirectionResponse Direction { get; set; }

    /// <summary>
    /// Модель курса
    /// </summary>
    public CourseResponse Course { get; set; }

    /// <summary>
    /// Модель проекта
    /// </summary>
    public ProjectResponse Project { get; set; }
}