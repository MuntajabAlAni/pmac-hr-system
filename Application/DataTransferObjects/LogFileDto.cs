using System;

namespace Application.DataTransferObjects;

public class LogFileDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public DateTime EntryTime { get; set; }
    public string? EntryType { get; set; }
    public string? EntryTable { get; set; }
    public Guid RecordId { get; set; }
    public string? NotificationString { get; set; }
    public string? EmployeeName { get; set; }
    public string? Link { get; set; }
    public int Military { get; set; }
}

public class LogFileForCreationDto
{
    public string? UserName { get; set; }
    public string? EntryType { get; set; }
    public string? EntryTable { get; set; }
    public Guid RecordId { get; set; }
    public string? NotificationString { get; set; }
    public string? EmployeeName { get; set; }
    public string? Link { get; set; }
    public int Military { get; set; }
}
