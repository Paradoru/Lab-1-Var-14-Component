using System;
using System.Collections.Generic;
abstract class Component // Абстрактный класс компонента
{
    protected string name;
    public Component(string name)
    {
        this.name = name;
    }
    public abstract void Add(Component component);
    public abstract void Remove(Component component);
    public abstract void Display(int depth);
}
class Case : Component // Класс для корпуса компьютера
{
    private List<Component> components = new List<Component>();

    public Case(string name) : base(name) { }

    public override void Add(Component component)
    {
        components.Add(component);
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        foreach (Component component in components)
        {
            component.Display(depth + 2);
        }
    }
}
class Frame : Component
{
    private List<Component> components = new List<Component>();
    public Frame(string name) : base(name) { }
    public override void Add(Component component)
    {
        components.Add(component);
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        foreach (Component component in components)
        {
            component.Display(depth + 2);
        }
    }
}
class DiskDrive : Component // Класс для дискового накопителя
{
    public DiskDrive(string name) : base(name) { }
    public override void Add(Component component)
    {
        Console.WriteLine("Невозможно добавить компонент к дисковому накопителю");
    }
    public override void Remove(Component component)
    {
        Console.WriteLine("Невозможно удалить компонент из дискового накопителя");
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }
}
class CircuitBoard : Component // Класс для электронной платы
{
    public CircuitBoard(string name) : base(name) { }
    public override void Add(Component component)
    {
        Console.WriteLine("Невозможно добавить компонент к электронной плате");
    }
    public override void Remove(Component component)
    {
        Console.WriteLine("Невозможно удалить компонент из электронной платы");
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Component computer = new Case("Компьютер");
        Component chassis = new Frame("Рама");
        Component diskDrive = new DiskDrive("Дисковый накопитель");
        Component circuitBoard = new CircuitBoard("Электронная плата");

        computer.Add(chassis); 
        chassis.Add(diskDrive);
        chassis.Add(circuitBoard);
        computer.Display(0);
    }
}