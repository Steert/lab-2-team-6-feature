using NUnit.Framework;
using task;

namespace task.Tests;

[TestFixture]
public class ScheduleTests
{
    [Test]
    public void Test_AddAndDelete()
    {
        var manager = new ScheduleManager();
        manager.AddEvent(new CalendarEvent("Пн", "A", 10, 20));
        manager.AddEvent(new CalendarEvent("Вт", "B", 30, 40));
        
        manager.DeleteEventByIndex(0);
        
        Assert.That(manager.count, Is.EqualTo(1));
        Assert.That(manager.schedule[0].Description, Is.EqualTo("B"));
    }
    
    [Test]
    public void Test_Report_Statistics()
    {
        var manager = new ScheduleManager();
        manager.AddEvent(new CalendarEvent("Пн", "Тест", 10, 20));
        
        string report = manager.GetReport();
        
        Assert.That(report, Is.EqualTo("Всього подій: 1"));
    }
    
    [Test]
    public void Test_Invalid_Parameters()
    {
        var manager = new ScheduleManager();
        manager.AddEvent(new CalendarEvent("Пн", "Ок", 10, 20));
        
        bool resultDelete = manager.DeleteEventByIndex(99);
        bool resultAdd = manager.AddEvent(null);
        
        Assert.That(resultDelete, Is.False);
        Assert.That(resultAdd, Is.False);
        Assert.That(manager.count, Is.EqualTo(1));
    }
    
    [Test]
    public void Test_Integration_FullWorkflow()
    {
        var manager = new ScheduleManager();
        
        manager.AddEvent(new CalendarEvent("Пн", "1", 10, 20));
        manager.AddEvent(new CalendarEvent("Вт", "2", 30, 40));
        manager.DeleteEventByIndex(0);
        
        Assert.That(manager.GetReport(), Is.EqualTo("Всього подій: 1"));
    }
    
    [Test]
    public void Test_Integration_Sort()
    {
        var manager = new ScheduleManager();
        manager.AddEvent(new CalendarEvent("Середа", "Last", 10, 20));
        manager.AddEvent(new CalendarEvent("Понеділок", "First", 10, 20));
        
        manager.Sort();
        
        Assert.That(manager.schedule[0].Day, Is.EqualTo("Понеділок"));
    }
}